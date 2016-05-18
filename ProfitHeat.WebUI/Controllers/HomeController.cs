using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
            ApplicationDbContext DbContext = new ApplicationDbContext();

            //var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(DbContext));
            //userManager.AddToRole(DbContext.Users.First(u => u.UserName == "1@1.ru").Id, "admin");

            string userName = User.Identity.Name;
            if (!String.IsNullOrWhiteSpace(userName))
                ViewBag.UserID = DbContext. Users.First(u => u.UserName == userName).Id;
            return View(DbContext.Projects.ToList());
        }
        //////////////////////////////////////////////////////////////////////
        public ActionResult InfoProject(int i = 12)
        {
            return PartialView(i);
        }



        //////////////////////////////////////////////////////////////////////
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