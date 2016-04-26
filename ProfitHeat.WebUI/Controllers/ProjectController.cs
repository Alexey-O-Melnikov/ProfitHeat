using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProfitHeat.Domain;

namespace ProfitHeat.WebUI.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index(int? id)
        {
            StoreEFContext DbContext = new StoreEFContext();
            if (id == null)
                return View();
            Project project = DbContext.Projects.Find(id);
            return View(project);
        }

    }
}