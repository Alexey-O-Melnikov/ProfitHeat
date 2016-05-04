using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProfitHeat.Domain;
using ProfitHeat.WebUI.Models;

namespace ProfitHeat.WebUI.Controllers
{
    public class ProjectController : Controller
    {
        StoreEFContext db = new StoreEFContext();
        // GET: Project
        public ActionResult Index(int? id)
        {
            //if (id == null)
            //    return View();
            var project = db.Projects.Find(id) ?? new Project { CreateDateTime = DateTime.Now };
            return View(project);
        }

        public PartialViewResult _Room(int? roomID)
        {
            var room = db.Rooms.Find(roomID);

            return PartialView(room);
        }

        public PartialViewResult _Radiator(int? radiatorID)
        {
            var radiator = db.Radiators.Find(radiatorID);

            return PartialView(radiator);
        }

        public PartialViewResult _Cladding(int? claddingID)
        {
            var cladding = db.Claddings.Find(claddingID);

            return PartialView(cladding);
        }

        public PartialViewResult _WallLayer(int? wallLayerID)
        {
            var wallLayer = db.WallLayers.Find(wallLayerID);

            return PartialView(wallLayer);
        }

        public PartialViewResult _Window(int? windowID, int? i)
        {
            ViewBag.NumWindow = i;
            var window = db.Windows.Find(windowID);

            return PartialView(window);
        }

        #region Tabular
        public PartialViewResult _Locations(int? locationID)
        {
            ViewBag.Location = db.Locations.Find(locationID)
                ?? new Location { Title = "" };
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
            ViewBag.TypeRoom = db.TypesRooms.Find(typeRoomID)
                ?? new TypeRoom { TitleTypeRoom = "" };
            var typeRooms = db.TypesRooms.ToList();

            return PartialView(typeRooms);
        }

        public PartialViewResult _ManufacturerRadiators(int? manufacturerRadiatorID)
        {
            TempData["manufacturerRadiator"] = db.ManufacturerRadiators.Find(manufacturerRadiatorID)
                ?? new ManufacturerRadiator { TitleCompany = "" };
            var manufacturerRadiators = db.ManufacturerRadiators.ToList();

            return PartialView(manufacturerRadiators);
        }

        public PartialViewResult _MaterialsRadiators(int? materialsRadiatorID)
        {
            TempData["materialsRadiator"] = db.MaterialRadiators.Find(materialsRadiatorID)
                ?? new MaterialRadiator { TitleMaterialRadiator = "" };
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

        public PartialViewResult _Radiators(int? radiatorID)
        {
            ViewBag.Radiator = db.Radiators.Find(radiatorID)
                ?? new Radiator { };////////////////////////////////////////////////////////////////////////
            var radiators = db.Radiators.ToList();

            return PartialView(radiators);
        }

        public PartialViewResult _Glasses(int? glassID)
        {
            ViewBag.Glass = db.Glasses.Find(glassID)
                ?? new Glass { };////////////////////////////////////////////////////////////////////////////
            var glasses = db.Glasses.ToList();

            return PartialView(glasses);
        }

        public PartialViewResult _WindowProfiles(int? windowProfileID)
        {
            ViewBag.WindowProfile = db.WindowsProfiles.Find(windowProfileID)
                ?? new WindowProfile { };////////////////////////////////////////////////////////////////////
            var windowProfiles = db.WindowsProfiles.ToList();

            return PartialView(windowProfiles);
        }

        public PartialViewResult _ManufacturerWindowProfiles(int? manufacturerWindowProfileID)
        {
            ViewBag.ManufacturerWindowProfile = db.ManufacturerWindowProfiles.Find(manufacturerWindowProfileID)
                ?? new ManufacturerWindowProfile { TitleCompany = "" };
            var manufacturerWindowProfiles = db.ManufacturerWindowProfiles.ToList();

            return PartialView(manufacturerWindowProfiles);
        }
        #endregion

    }
}