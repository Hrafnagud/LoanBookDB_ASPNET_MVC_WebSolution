using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoanBookDB_ASPNET_MVC_Web_BLL;
using LoanBookDB_ASPNET_MVC_Web_BLL.Managers;
using LoanBookDB_ASPNET_MVC_Web.Models;
using System.IO;

namespace LoanBookDB_ASPNET_MVC_Web.Controllers
{
    public class BookController : Controller
    {
        BookManager bookManager = new BookManager();
        AuthorManager authorManager = new AuthorManager();
        GenreManager genreManager = new GenreManager();
        public const int pageSize = 10;
        // GET: Book
        public ActionResult Index(int? page = 1)
        {
            try
            {
                List<Book> bookList = bookManager.BringAllActiveBooks().Skip((page.Value < 1 ? 1 : page.Value - 1) * pageSize).Take(pageSize).ToList();
                var total = bookManager.BringAllActiveBooks().Count();
                ViewBag.TotalPages = (int)Math.Ceiling(total / (double)pageSize);
                ViewBag.Now = page;
                ViewBag.PageSize = pageSize;
                ViewBag.BookListCount = 0;
                if (bookList.Count > 0)
                {
                    ViewBag.BookListCount = bookList.Count;
                }
                return View(bookList);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Unexpected error has occured";
                //ex.Message can be logged
                return View();
            }
        }

        [HttpGet]
        public ActionResult Add()
        {
            List<SelectListItem> genreList = new List<SelectListItem>();
            genreManager.BringAllActiveGenre()
                .ForEach(x =>
                genreList.Add(new SelectListItem()
                {
                    Text = x.GenreName,
                    Value = x.Id.ToString()
                }));
            ViewBag.GenreList = genreList;

            List<SelectListItem> authorList = new List<SelectListItem>();
            authorManager.BringAllActiveAuthors()
                .ForEach(x =>
                authorList.Add(new SelectListItem()
                {
                    Text = x.AuthorName + " " + x.AuthorSurname,
                    Value = x.Id.ToString()
                }));
            ViewBag.AuthorList = authorList;
            return View(new BookViewModel());
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Add(BookViewModel newBook)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "All fields must be filled");
                    return View(newBook);
                }

                Book bookToAdd = new Book()
                {
                    DateRegistered = DateTime.Now,
                    BookName = newBook.BookName,
                    Pages = newBook.Pages,
                    Stock = newBook.Stock,
                    AuthorId = newBook.AuthorId,
                    GenreId = newBook.GenreId
                };
                //If image != null, will be saved into system.
                if (newBook.Image != null && newBook.Image.ContentType.Contains("image") && newBook.Image.ContentLength > 0)
                {
                    //string fileName = Path.GetFileNameWithoutExtension(newBook.Image.FileName);
                    string fileName = SiteSettings.CharacterFormatConverter(newBook.BookName).ToLower();
                    string extensionName = Path.GetExtension(newBook.Image.FileName);
                    fileName += "-" + Guid.NewGuid().ToString().Replace("-", "");
                    var directoryPath = Server.MapPath($"~/BookImages/");
                    var filePath = Server.MapPath($"~/BookImages/") + fileName + extensionName;
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }
                    newBook.Image.SaveAs(filePath);
                    bookToAdd.ImageLink = @"/BookImages/" + fileName + extensionName;
                }

                if (bookManager.AddNewBook(bookToAdd))
                {
                    return RedirectToAction("Index", "Book");
                }
                else
                {
                    ModelState.AddModelError("", "An error has occured!");
                    //TO DO: ex.Message can be logged.
                    return View(newBook);
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unexpected error has occured!");
                //TO DO: ex.Message can be logged.
                return View(newBook);
            }
        }

    }
}