using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitHeat.Domain
{
    /// <summary>
    /// оконный профиль
    /// </summary>
    public class WindowProfile 
    {
        public int WindowProfileID { get; set; }
        /// <summary>
        /// количество камер
        /// </summary>
        public int CountCameras { get; set; }
        /// <summary>
        /// толщина профиля
        /// </summary>
        public int Thickness { get; set; }
        /// <summary>
        /// коэффициент теплосопротивления (R) (м² * °С / Вт)
        /// </summary>
        public double HeatResistanceCoefficient { get; set; }
    }
}
