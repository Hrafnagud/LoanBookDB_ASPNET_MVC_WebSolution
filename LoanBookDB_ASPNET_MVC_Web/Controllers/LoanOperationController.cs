using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoanBookDB_ASPNET_MVC_Web_BLL;
using LoanBookDB_ASPNET_MVC_Web_BLL.Managers;
using LoanBookDB_ASPNET_MVC_Web.Models;

namespace LoanBookDB_ASPNET_MVC_Web.Controllers
{
    public class LoanOperationController : Controller
    {
        BookManager bookManager = new BookManager();
        CustomerManager customerManager = new CustomerManager();
        LoanOperationManager loanOperationManager = new LoanOperationManager();
        // GET: LoanOperation
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            List<SelectListItem> bookList = new List<SelectListItem>();
            bookManager.BringAllActiveBooks()
                .ForEach(x =>
                bookList.Add(new SelectListItem()
                {
                    Text = x.BookName,
                    Value = x.Id.ToString()
                }));
            ViewBag.BookList= bookList;

            List<SelectListItem> customerList = new List<SelectListItem>();
            customerManager.BringAllActiveCustomers()
                .ForEach(x =>
                customerList.Add(new SelectListItem()
                {
                    Text = x.CustomerName + " " + x.CustomerSurname,
                    Value = x.Id.ToString()
                }));
            ViewBag.CustomerList = customerList;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(LoanOperationViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Provide valid data");
                    return View(model);
                }

                Loan newLoanOperation = new Loan()
                {
                    DateRegistered = DateTime.Now,
                    BookId = model.BookId,
                    CustomerId = model.CustomerId,
                    LoanStarts = model.LoanStarts,
                    PersonnelId = 1
                };

                newLoanOperation.LoanEnds = model.LoanStarts.AddDays(15);
                newLoanOperation.IsReturned = false;

                if (loanOperationManager.AddLoanOperation(newLoanOperation))
                {
                    return RedirectToAction("Index", "LoanOperation");
                }
                else
                {
                    ModelState.AddModelError("", "Error has occured during loan book operations. Refresh the page and try again.");
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }
    }
}