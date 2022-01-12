using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoanBookDB_ASPNET_MVC_Web_BLL;
using LoanBookDB_ASPNET_MVC_Web_BLL.Managers;

namespace LoanBookDB_ASPNET_MVC_Web.Controllers
{
    public class BookController : Controller
    {
        BookManager bookManager = new BookManager();
        // GET: Book
        public ActionResult Index()
        {
            try
            {
                List<Book> bookList = bookManager.BringAllActiveBooks();
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
    }
}