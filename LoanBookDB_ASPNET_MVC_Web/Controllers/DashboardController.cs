using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoanBookDB_ASPNET_MVC_Web_BLL.Managers;

namespace LoanBookDB_ASPNET_MVC_Web.Controllers
{
    public class DashboardController : Controller
    {
        BookManager bookManager = new BookManager();
        // GET: Dashboard
        public ActionResult Index()
        {
            ViewBag.BooksAddedToday = bookManager.BringAllActiveBooks().Where(x => x.DateRegistered > DateTime.Now.AddDays(-1)
            && x.DateRegistered < DateTime.Now.AddDays(1)).Count();
            return View();
        }
    }
}