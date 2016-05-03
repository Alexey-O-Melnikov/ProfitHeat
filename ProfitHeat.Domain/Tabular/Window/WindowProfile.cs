using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public int ManufacturerWindowProfileID { get; set; }
        /// <summary>
        /// компания производитель
        /// </summary>
        public virtual ManufacturerWindowProfile ManufacturerWindowProfile { get; set; }
        /// <summary>
        /// название марки
        /// </summary>
        [DisplayName("Модель")]
        public string TitleMark { get; set; }
        /// <summary>
        /// количество камер
        /// </summary>
        [DisplayName("Количество камер")]
        public int CountCameras { get; set; }
        /// <summary>
        /// толщина профиля
        /// </summary>
        [DisplayName("Толщина профиля")]
        public int Thickness { get; set; }
        /// <summary>
        /// коэффициент теплосопротивления (R) (м² * °С / Вт)
        /// </summary>
        public double HeatResistanceCoefficient { get; set; }
    }
}
