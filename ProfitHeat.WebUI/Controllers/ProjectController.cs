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
            var project = db.Projects.Find(projectID);
            if (project == null)
            {
                var user = db.Users.First(u => u.UserName == User.Identity.Name);
                project = new NewProject().GetNewProject(user, db);
                db.Projects.Add(project);
                db.SaveChanges();
            }

            return View(project);
        }

        public PartialViewResult _SaveProject(int? projectID)
        {
            var project = db.Projects.Find(projectID);

            return PartialView(project);
        }

        public PartialViewResult _Result(int? projectID)
        {
            CalculationHeatingSystem calc = new CalculationHeatingSystem(projectID);

            ViewBag.PowerBoiler = calc.PowerBoiler;
            ViewBag.DiameterCoolant = calc.DiameterCoolant;
            ViewBag.Radiators = calc.Radiators;

            return PartialView();
        }

        public PartialViewResult _ListNameRooms(int? projectID, string roomName)
        {
            ViewBag.Room = roomName;
            var rooms = db.Rooms.Where(r => r.ProjectID == projectID).ToList();

            return PartialView(rooms);
        }

        public PartialViewResult _Room(int? projectID, string roomName)
        {
            var room = db.Rooms.Where(r => r.Title == roomName).FirstOrDefault();
            if (room == null)
            {
                room = new NewProject().GetNewRoom(db, roomName);
                db.Projects.Find(projectID).Rooms.Add(room);
                db.SaveChanges();
            }

            return PartialView(room);
        }

        public PartialViewResult _Cladding(int? claddingID, int? wallLayerID)
        {
            var cladding = db.Claddings.Find(claddingID);
            if (wallLayerID != null)
            {
                var wallLayer = db.WallLayers.Find(wallLayerID);
                db.WallLayers.Remove(wallLayer);
                db.SaveChanges();
            }

            return PartialView(cladding);
        }

        public PartialViewResult _WallLayer(int? claddingID, int? wallLayerID)
        {
            var wallLayer = db.WallLayers.Find(wallLayerID);
            if(wallLayer == null)
            {
                wallLayer = new WallLayer
                {
                    Material = db.Materials.First(),
                    CladdingID = (int)claddingID,
                    Thickness = 0,
                    NumLayer = /*db.Claddings.Find(claddingID)
                        .WallLayers.OrderByDescending(w => w.NumLayer).First().NumLayer + */1
                };
                db.WallLayers.Add(wallLayer);
                db.SaveChanges();
            }

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

        public PartialViewResult _Materials(int? materialID, int? layerID)
        {
            ViewBag.LayerID = layerID;
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

        public PartialViewResult _MaterialsRadiators(int? materialsRadiatorID)
        {
            ViewBag.MaterialRadiator = db.MaterialRadiators.Find(materialsRadiatorID);
            var materialsRadiators = db.MaterialRadiators.ToList();

            return PartialView(materialsRadiators);
        }

        public PartialViewResult _ManufacturerRadiators(string materialRadiator, string manufacturerRadiator)
        {
            ViewBag.ManufacturerRadiator = manufacturerRadiator;
            var radiators = db.Radiators.Where(r => r.MaterialRadiator.TitleMaterialRadiator == materialRadiator).ToList();
            var manufacturerRadiators = new List<ManufacturerRadiator>();
            foreach (var radiator in radiators)
            {
                var temp = manufacturerRadiators.Find(m => m.TitleCompany == radiator.ManufacturerRadiator.TitleCompany);
                if (temp == null)
                    manufacturerRadiators.Add(radiator.ManufacturerRadiator);
            }

            return PartialView(manufacturerRadiators);
        }

        public PartialViewResult _ModelRadiator(string materialRadiator, string manufacturerRadiator, string modelRadiator )
        {
            ViewBag.ModelRadiator = modelRadiator;
            var modelRadiators = db.Radiators
                .Where(x => x.MaterialRadiator.TitleMaterialRadiator == materialRadiator 
                && x.ManufacturerRadiator.TitleCompany == manufacturerRadiator).ToList();

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
            var glass = db.Glasses.Find(glassID);

            return PartialView(glass);
        }

        public PartialViewResult _CountCameras(int? countCameras)
        {
            ViewBag.CountCameras = countCameras;
            List<int> countsCameras = new List<int>();
            foreach (var glass in db.Glasses)
            {
                if (countsCameras.Where(x => x == glass.CountCamera).Count() == 0)
                    countsCameras.Add(glass.CountCamera);
            }

            return PartialView(countsCameras);
        }

        public PartialViewResult _DistanceBetweenGlasses(int? countCameras, int? distanceBetweenGlasses)
        {
            ViewBag.DistanceBetweenGlass = distanceBetweenGlasses;
            List<int> distancesBetweenGlasses = new List<int>();
            var glasses = db.Glasses.Where(g => g.CountCamera == countCameras);
            foreach (var glass in glasses)
            {
                if (distancesBetweenGlasses.Where(x => x == glass.DistanceBetweenGlasses).Count() == 0)
                    distancesBetweenGlasses.Add(glass.DistanceBetweenGlasses);
            }

            return PartialView(distancesBetweenGlasses);
        }

        public PartialViewResult _TypeGlasses(int? countCameras, int? distanceBetweenGlasses, string typeGlasses)
        {
            ViewBag.TypeGlasses = typeGlasses;
            var glasses = db.Glasses.Where(g => g.CountCamera == countCameras && g.DistanceBetweenGlasses == distanceBetweenGlasses).ToList();

            return PartialView(glasses);
        }

        public PartialViewResult _WindowProfiles(string manufactProfile, string winProf)
        {
            ViewBag.WindowProfile = winProf;
            var windowProfiles = db.WindowsProfiles.Where(p => p.ManufacturerWindowProfile.TitleCompany == manufactProfile).ToList();

            return PartialView(windowProfiles);
        }

        public PartialViewResult _ManufacturerWindowProfiles(int? manufacturerWindowProfileID)
        {
            ViewBag.ManufacturerWindowProfile = db.ManufacturerWindowProfiles.Find(manufacturerWindowProfileID);
            var manufacturerWindowProfiles = db.ManufacturerWindowProfiles.ToList();

            return PartialView(manufacturerWindowProfiles);
        }
        #endregion





        #region SaveData
        public void SaveEntity(string entity, int? id, string value)
        {
            new SaveData(db).Save(entity, id, value);
        }

        public void SaveRadiator(int? roomID, string model, string material, string manufect)
        {
            string radiatorID = db.Radiators.First(r => r.TitleModel == model
                && r.MaterialRadiator.TitleMaterialRadiator == material
                && r.ManufacturerRadiator.TitleCompany == manufect).RadiatorID.ToString();

            new SaveData(db).Save("Radiator", roomID, radiatorID);
        }

        public void SaveGlass(int? windowID, string glassType, int camerasCount, int distanc)
        {
            string glassID = db.Glasses.First(g => g.Type == glassType
                && g.CountCamera == camerasCount
                && g.DistanceBetweenGlasses == distanc).GlassID.ToString();

            new SaveData(db).Save("Glass", windowID, glassID);
        }

        public void SaveWindowProfile(int? windowID, string model, string manufect)
        {
            string profileID = db.WindowsProfiles.First(p => p.TitleMark == model
                && p.ManufacturerWindowProfile.TitleCompany == manufect).WindowProfileID.ToString();

            new SaveData(db).Save("WindowProfile", windowID, profileID);
        }
        #endregion
         protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}