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
        public ActionResult Index(int projectID = 1)
        {
            StoreEFContext DbContext = new StoreEFContext();
            Project project = DbContext.Projects.Find(projectID);
            return View(project);
        }
    }
}