using ProfitHeat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitHeat.WebUI.Models
{
    public class SaveData
    {
        ApplicationDbContext db = null;
        public SaveData(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Save(string entity, int? id, string value)
        {
            switch(entity)
            {
                case "ProjectTitle":
                    db.Projects.Find(id).Title = value;
                    break;
                case "LocationTitle":
                    db.Projects.Find(id).LocationID = db.Locations.First(l => l.Title == value).LocationID;
                    break;
                case "RoomTitle":
                    db.Rooms.Find(id).Title = value;
                    break;
                case "RoomLevel":
                    db.Rooms.Find(id).Level = int.Parse(value);
                    break;
                case "RoomType":
                    db.Rooms.Find(id).TypeRoomID = db.TypesRooms.First(t => t.TitleTypeRoom == value).TypeRoomID;
                    break;
                case "Radiator":
                    db.Rooms.Find(id).RadiatorID = int.Parse(value);
                    break;
                case "CladdingArea":
                    db.Claddings.Find(id).Area = int.Parse(value);
                    break;
                case "LayerMaterial":
                    db.WallLayers.Find(id).MaterialID = db.Materials.First(m => m.Title == value).MaterialID;
                    break;
                case "LayerThickness":
                    db.WallLayers.Find(id).Thickness = double.Parse(value);
                    break;
                case "WindowArea":
                    db.Windows.Find(id).WindowArea = double.Parse(value);
                    break;
                case "Glass":
                    db.Windows.Find(id).GlassID = int.Parse(value);
                    break;
                case "GlassArea":
                    db.Windows.Find(id).GlassArea = double.Parse(value);
                    break;
                case "WindowProfile":
                    db.Windows.Find(id).WindowProfileID = int.Parse(value);
                    break;
            }
            db.SaveChanges();
        }




        public void ProjectTitle(int? projectID, string title)
        {
            db.Projects.Find(projectID).Title = title;
            db.SaveChanges();
        }
        public void LocationTitle(int? projectID, int locationID)
        {
            db.Projects.Find(projectID).LocationID = locationID;
            db.SaveChanges();
        }
        public void RoomTitle(int? roomID, string title)
        {
            db.Rooms.Find(roomID).Title = title;
            db.SaveChanges();
        }
        public void RoomLevel(int? roomID, int level)
        {
            db.Rooms.Find(roomID).Level = level;
            db.SaveChanges();
        }
        public void RoomType(int? roomID, int roomTypeID)
        {
            db.Rooms.Find(roomID).TypeRoomID = roomTypeID;
            db.SaveChanges();
        }
        public void Radiator(int? roomID, int radiatorID)
        {
            db.Rooms.Find(roomID).RadiatorID = radiatorID;
            db.SaveChanges();
        }
        public void CladdingArea(int? claddingID, double area)
        {
            db.Claddings.Find(claddingID).Area = area;
            db.SaveChanges();
        }
        public void LayerMaterial(int? layerID, int materialID)
        {
            db.WallLayers.Find(layerID).MaterialID = materialID;
            db.SaveChanges();
        }
        public void LayerThickness(int? layerID, double thickness)
        {
            db.WallLayers.Find(layerID).Thickness = thickness;
            db.SaveChanges();
        }
        public void WindowArea(int? windowID, double area)
        {
            db.Windows.Find(windowID).WindowArea = area;
            db.SaveChanges();
        }
        public void Glass(int? windowID, int glassID)
        {
            db.Windows.Find(windowID).GlassID = glassID;
            db.SaveChanges();
        }
        public void GlassArea(int? windowID, double area)
        {
            db.Windows.Find(windowID).GlassArea = area;
            db.SaveChanges();
        }
        public void WindowProfile(int? windowID, int windowProfileID)
        {
            db.Windows.Find(windowID).WindowProfileID = windowProfileID;
            db.SaveChanges();
        }
    }
}
