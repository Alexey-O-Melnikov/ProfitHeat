using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfitHeat.Domain;

namespace ProfitHeat.WebUI.Models
{
    public class CalculationHeatingSystem
    {
        public double PowerBoiler { get; set; }
        public int DiameterCoolant { get; set; }
        public List<CountSectionRadiator> Radiators { get; set; }

        Project project = null;

        public CalculationHeatingSystem(int? projectID)
        {
            Calculation(projectID);
        }

        private void Calculation(int? projectID)
        {
            var db = new ApplicationDbContext();
            project = db.Projects.Find(projectID);

            ///мощность котла
            double powerBoiler = 0;
            ///диаметр теплоносителя
            int diameterCoolant = 0;
            ///количество секций радиаора на каждую комнату
            List<CountSectionRadiator> radiators = new List<CountSectionRadiator>();

            double heatLoss = 0;
            foreach (var room in project.Rooms)
            {
                double Q = GetHeatLossRoom(room);

                radiators.Add(new CountSectionRadiator
                {
                    NameRoom = room.Title,
                    CountSection = (int)Math.Floor(Q/room.Radiator.ThermalPower)
                });

                heatLoss += Q;
            }
            powerBoiler = Math.Ceiling(heatLoss);

            foreach (var pipe in db.Pipes)
            {
                if(pipe.BoilerPower > powerBoiler)
                {
                    diameterCoolant = pipe.Diametr;
                    break;
                }
            }

            PowerBoiler = powerBoiler;
            DiameterCoolant = diameterCoolant;
            Radiators = radiators;
        }

        /// <summary>
        /// теплопотери комнаты
        /// </summary>
        private double GetHeatLossRoom(Room room)
        {
            double heatLoss = 0;
            int temperatureIn = room.TypeRoom.ComfortableTemperature;

            foreach (var cladding in room.Claddings)
            {
                heatLoss += GetHeatLossCladding(cladding, temperatureIn);
            }

            foreach (var window in room.Windows)
            {
                heatLoss += GetHeatLossWindow(window, temperatureIn);
            }

            heatLoss = GetHeatLossInfiltration(heatLoss, temperatureIn);

            return heatLoss;
        }

        /// <summary>
        /// теплопотери ограждающей конструкции
        /// </summary>
        private double GetHeatLossCladding(Cladding cladding, int temperatureIn)
        {
            double heatLoss = 0;
            /// коэффициент теплоотдачи внутренний (α_вн)
            double HeatIrradiationCoefficientIn = 8.7;
            /// коэффициент теплоотдачи внешний (α_н)
            double HeatIrradiationCoefficientOut = 23;

            heatLoss += 1 / HeatIrradiationCoefficientIn + 1 / HeatIrradiationCoefficientOut;
            foreach (var wallLayer in cladding.WallLayers)
            {
                heatLoss += wallLayer.Thickness / wallLayer.Material.HeatConductivityCoefficient;
            }

            heatLoss += 1/heatLoss * cladding.Area * (temperatureIn - project.Location.MinTemperature);

            return heatLoss;
        }

        /// <summary>
        /// теплопотери окна
        /// </summary>
        private double GetHeatLossWindow(Window window, int temperatureIn)
        {
            double heatLoss = 0;

            heatLoss += GetHeatLossWindowGlass(window) * (temperatureIn - project.Location.MinTemperature);
            heatLoss += GetHeatLossWindowProfile(window) * (temperatureIn - project.Location.MinTemperature);

            return heatLoss;
        }

        /// <summary>
        /// теплопотери стеклопакета
        /// </summary>
        private double GetHeatLossWindowGlass(Window window)
        {
            double SK = 0;

            SK += window.GlassArea / window.Glass.HeatResistanceCoefficient;

            return SK;
        }

        /// <summary>
        /// теплопотери профиля окна
        /// </summary>
        private double GetHeatLossWindowProfile(Window window)
        {
            double SK = 0;

            SK += (window.WindowArea - window.GlassArea) / window.WindowProfile.HeatResistanceCoefficient;

            return SK;
        }

        /// <summary>
        /// теплопотери инфильтрации
        /// </summary>
        private double GetHeatLossInfiltration(double QRooms, int temperatureIn)
        {
            double heatLoss = 0;
            double zeroToKelvin = 273;
            double b = 0.035;
            double g = 9.81;
            double H = 3;
            double Tin = zeroToKelvin + temperatureIn;
            double Tout = zeroToKelvin + project.Location.MinTemperature;
            double w = 2;

            double mu = b * Math.Sqrt(2 * g * H * (1 - Tout / Tin) + Math.Pow(w, 2));
            heatLoss = (1 + mu) * QRooms;

            return heatLoss;
        }
    }

    public class CountSectionRadiator
    {
        public string NameRoom { get; set; }
        public int CountSection { get; set; }
    }
}
