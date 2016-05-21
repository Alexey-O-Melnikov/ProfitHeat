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
        Project project;
        public Project GetNewProject(string userID)
        {
            project = new Project
            {
                UserID = userID,
                Title = "New",
                CreateDateTime = DateTime.Now,
                Location = new Location(),
                Rooms = new List<Room>
                    {
                        new Room
                        {
                            Title = "",
                            TypeRoom = new TypeRoom(),
                            Level = 1,
                            Claddings = new List<Cladding>
                            {
                                new Wall
                                {
                                    CladdingType = "Стена",
                                    WallLayers = new List<WallLayer>
                                    {
                                        new WallLayer()
                                    }
                                }
                            },
                            Windows = new List<Window>
                            {
                                new Window()
                            },
                            Radiator = new Radiator(),
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
