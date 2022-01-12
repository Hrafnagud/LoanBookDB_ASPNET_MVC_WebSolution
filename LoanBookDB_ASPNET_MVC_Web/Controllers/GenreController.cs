using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoanBookDB_ASPNET_MVC_Web_BLL;
using LoanBookDB_ASPNET_MVC_Web_BLL.Managers;

namespace LoanBookDB_ASPNET_MVC_Web.Controllers
{
    public class GenreController : Controller
    {
        GenreManager genreManager = new GenreManager();

        // GET: Genre

        public ActionResult Index()
        {
            //Genre will be transfered
            try
            {
                List<Genre> genreList = genreManager.BringAllActiveGenre();
                ViewBag.GenreListCount = 0;
                if (genreList.Count > 0)
                {
                    ViewBag.GenreListCount = genreList.Count;
                }
                return View(genreList);
            }
            catch (Exception ex)
            {

            }
            return View();
        }
    }
}