using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfitHeat.Domain;

namespace ProfitHeat.WebUI.Models
{
    public class NewProject
    {
        public Project GetNewProject(ApplicationUser user, ApplicationDbContext db)
        {
            Project project = new Project
            {
                ApplicationUser = user,
                Title = "New",
                CreateDateTime = DateTime.Now,
                Location = db.Locations.First(), //
                Rooms = new List<Room>
                    {
                        new Room
                        {
                            Title = "New",
                            TypeRoom = db.TypesRooms.First(), //
                            Level = 1,
                            Radiator = db.Radiators.First(),
                            RadiatorID = db.Radiators.First().RadiatorID,
                            Claddings = new List<Cladding>
                            {
                                new Wall
                                {
                                    Area = 0,
                                    CladdingType = "Стена",
                                    WallLayers = new List<WallLayer>
                                    {
                                        new WallLayer
                                        {
                                            Material = db.Materials.First(), //
                                            Thickness = 0
                                        }
                                    }
                                },
                                new Floor
                                {
                                    Area = 0,
                                    CladdingType = "Полы",
                                    WallLayers = new List<WallLayer>
                                    {
                                        new WallLayer
                                        {
                                            Material = db.Materials.First(), //
                                            Thickness = 0
                                        }
                                    }
                                },
                                new Roof
                                {
                                    Area = 0,
                                    CladdingType = "Потолок",
                                    WallLayers = new List<WallLayer>
                                    {
                                        new WallLayer
                                        {
                                            Material = db.Materials.First(), //
                                            Thickness = 0
                                        }
                                    }
                                },
                                new Door
                                {
                                    Area = 0,
                                    CladdingType = "Дверь",
                                    WallLayers = new List<WallLayer>
                                    {
                                        new WallLayer
                                        {
                                            Material = db.Materials.First(), //
                                            Thickness = 0
                                        }
                                    }
                                }
                            },
                            Windows = new List<Window>
                            {
                                new Window
                                {
                                    WindowArea = 0,
                                    Glass = db.Glasses.First(), //
                                    GlassArea = 0,
                                    WindowProfile = db.WindowsProfiles.First(), //
                                }
                            }
                        }
                    },
                Layers = new List<Layer>
                    {
                        new Layer
                        {
                            LayerNumber = 1,
                            Items = new List<Item>()
                        }
                    }
            };

            return project;
        }
    }
}
