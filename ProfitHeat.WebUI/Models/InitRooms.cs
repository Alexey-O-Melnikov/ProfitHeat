using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfitHeat.Domain;

namespace ProfitHeat.WebUI.Models
{
    public class InitRooms 
    {
        public Room GetRoom()
        {
            return new Room
            {
                RoomID = 1,
                ProjectID = 1,
                Title = "First Room",
                Level = 1,
                TypeRoomID = 1,
                RadiatorID = 1,
                Windows = new List<Window>
                {
                    new Window
                    {
                        WindowID = 1,
                        GlassID = 1,
                        WindowProfileID = 1,
                        GlassArea = 3,
                        WindowArea = 4,
                    },
                    new Window
                    {
                        WindowID = 2,
                        GlassID = 2,
                        WindowProfileID = 2,
                        GlassArea = 3,
                        WindowArea = 4,
                    }
                },
                Claddings = new List<Cladding>
                {
                    new Wall
                    {
                        Area = 10,
                        CladdingID = 1,
                        WallLayers = new List<WallLayer>
                        {
                            new WallLayer
                            {
                                WallLayerID = 1,
                                MaterialID = 1,
                                Thickness = 1,
                            },
                            new WallLayer
                            {
                                WallLayerID = 2,
                                MaterialID = 2,
                                Thickness = 1,
                            }

                        }
                    },
                    new Floor
                    {
                        Area = 15,
                        CladdingID = 2,
                        WallLayers = new List<WallLayer>
                        {
                            new WallLayer
                            {
                                WallLayerID = 3,
                                MaterialID = 3,
                                Thickness = 1,
                            },
                            new WallLayer
                            {
                                WallLayerID = 4,
                                MaterialID = 4,
                                Thickness = 1,
                            }

                        }

                    }
                }
            };
        }
    }
}
