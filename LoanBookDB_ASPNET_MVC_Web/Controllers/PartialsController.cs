using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoanBookDB_ASPNET_MVC_Web_BLL.Managers;

namespace LoanBookDB_ASPNET_MVC_Web.Controllers
{
    public class PartialsController : Controller
    {
        BookManager bookManager = new BookManager();
        //To manage all partials in one place we created partial controller. You can create partial controller inside any of your controllers
        //if necessary

        public PartialViewResult PartialMenuResult()
        {
            //TODO: 
            int totalBooks = bookManager.BringAllActiveBooks().Count();
            TempData["TotalBooks"] = totalBooks;
            return PartialView("_PartialMenu");
        }
    }
}