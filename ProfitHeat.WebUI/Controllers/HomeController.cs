using ProfitHeat.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace ProfitHeat.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //try
            //{
            //    DbContext = new ApplicationDbContext();
            //    DbContext.Database.Initialize(false);
            //}
            //catch (Exception ex)
            //{
            //    for (int i = 0; i < 10; i++)
            //    {
            //        Debug.WriteLine("Инициализация не выполнена. Ошибка: ");
            //        Debug.WriteLine(ex.Message);
            //        Thread.Sleep(300);
            //    }
            //}

            ApplicationDbContext DbContext = new ApplicationDbContext();
            ViewBag.UserID = "2a19a491-b520-4db8-b18b-877a24d66603";
            return View(DbContext.Projects.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}