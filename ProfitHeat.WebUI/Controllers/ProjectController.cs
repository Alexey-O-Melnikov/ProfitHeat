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
            using (StoreEFContext DbContext = new StoreEFContext())
            {
                if (id == null)
                    return View();
                var project = DbContext.Projects.Find(id);
                return View(project);
            }
        }

        public PartialViewResult _Location(int locationId)
        {
            using (StoreEFContext db = new StoreEFContext())
            {
                ViewBag.Location = db.Locations.Find(locationId);
                var locations = db.Locations.ToList();

                return PartialView(locations);
            }
        }

        public PartialViewResult _Materials(int materialID)
        {
            using (StoreEFContext db = new StoreEFContext())
            {
                ViewBag.Material = db.Materials.Find(materialID);
                var materials = db.Materials.ToList();

                return PartialView(materials);
            }
        }
    }
}