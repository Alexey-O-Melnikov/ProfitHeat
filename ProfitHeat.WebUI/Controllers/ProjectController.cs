using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProfitHeat.Domain;
using ProfitHeat.WebUI.Models;

namespace ProfitHeat.WebUI.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Project
        public ActionResult Index(int? projectID)
        {
            Project project = db.Projects.Find(projectID);
            if (project == null)
            {
                var user = db.Users.First(u => u.UserName == User.Identity.Name);
                project = new NewProject().GetNewProject(user, db);
                db.Projects.Add(project);
                var pr = db.Projects.Where(p => p.Title == "New").FirstOrDefault();
                if(pr != null)
                    db.Projects.Remove(pr);
                db.SaveChanges();
            }

            return View(project);
        }

        public PartialViewResult _Result(int? projectID)
        {
            CalculationHeatingSystem calc = new CalculationHeatingSystem(projectID);

            ViewBag.PowerBoiler = calc.PowerBoiler;
            ViewBag.DiameterCoolant = calc.DiameterCoolant;
            ViewBag.Radiators = calc.Radiators;

            return PartialView();
        }

        public PartialViewResult _Level(int? level)
        {
            ViewBag.Level = level;
            var layers = db.Layers.ToList();

            return PartialView(layers);
        }

        public PartialViewResult _Layers(int? level)
        {
            ViewBag.Layer = db.Layers.Where(x => x.LayerNumber == level).First();
            var layers = db.Layers.ToList();

            return PartialView(layers);
        }

        public PartialViewResult _Room(int roomID = 0)
        {
            var room = db.Rooms.Find(roomID); 

            return PartialView(room);
        }

        public PartialViewResult _Cladding(int? claddingID)
        {
            var cladding = db.Claddings.Find(claddingID);

            return PartialView(cladding);
        }

        public PartialViewResult _WallLayer(int? wallLayerID)
        {
            var wallLayer = db.WallLayers.Find(wallLayerID) ?? new WallLayer();

            return PartialView(wallLayer);
        }

        public PartialViewResult _Window(int? windowID)
        {
            var window = db.Windows.Find(windowID);

            return PartialView(window);
        }

        #region Tabular
        public PartialViewResult _Locations(int? locationID)
        {
            ViewBag.Location = db.Locations.Find(locationID);
            var locations = db.Locations.ToList();

            return PartialView(locations);
        }

        public PartialViewResult _Materials(int? materialID)
        {
            ViewBag.Material = db.Materials.Find(materialID) 
                ?? new Material { Title = "" };
            var materials = db.Materials.ToList();

            return PartialView(materials);
        }

        public PartialViewResult _TypeRooms(int? typeRoomID)
        {
            ViewBag.TypeRoom = db.TypesRooms.Find(typeRoomID);
            var typeRooms = db.TypesRooms.ToList();

            return PartialView(typeRooms);
        }

        public PartialViewResult _ManufacturerRadiators(int? manufacturerRadiatorID)
        {
            ViewBag.ManufacturerRadiator = db.ManufacturerRadiators.Find(manufacturerRadiatorID);
            var manufacturerRadiators = db.ManufacturerRadiators.ToList();

            return PartialView(manufacturerRadiators);
        }

        public PartialViewResult _MaterialsRadiators(int? materialsRadiatorID)
        {
            ViewBag.MaterialRadiator = db.MaterialRadiators.Find(materialsRadiatorID);
            var materialsRadiators = db.MaterialRadiators.ToList();

            return PartialView(materialsRadiators);
        }

        public PartialViewResult _ModelRadiator(int? radiatorID, int? manufacturerRadiatorID, int? materialRadiatorID)
        {
            ViewBag.ModelRadiator = db.Radiators.Find(radiatorID);
            var modelRadiators = db.Radiators
                .Where(x => x.ManufacturerRadiatorID == manufacturerRadiatorID
                    && x.MaterialRadiatorID == materialRadiatorID).ToList();

            return PartialView(modelRadiators);
        }

        public ActionResult _Radiator(int? radiatorID)
        {
            ViewBag.Radiator = db.Radiators.Find(radiatorID);
            var radiator = db.Radiators.Find(radiatorID);
            return PartialView(radiator);
        }

        public PartialViewResult _Glasses(int? glassID)
        {
            ViewBag.Glass = db.Glasses.Find(glassID);
            var glasses = db.Glasses.ToList();

            return PartialView(glasses);
        }

        public PartialViewResult _WindowProfiles(int? windowProfileID)
        {
            ViewBag.WindowProfile = db.WindowsProfiles.Find(windowProfileID);
            var windowProfiles = db.WindowsProfiles.ToList();

            return PartialView(windowProfiles);
        }

        public PartialViewResult _ManufacturerWindowProfiles(int? manufacturerWindowProfileID)
        {
            ViewBag.ManufacturerWindowProfile = db.ManufacturerWindowProfiles.Find(manufacturerWindowProfileID);
            var manufacturerWindowProfiles = db.ManufacturerWindowProfiles.ToList();

            return PartialView(manufacturerWindowProfiles);
        }
        #endregion

    }
}