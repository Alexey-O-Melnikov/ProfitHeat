using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "Укажите модель оконного профиля")]
        public string TitleMark { get; set; }
        /// <summary>
        /// количество камер
        /// </summary>
        [DisplayName("Количество камер")]
        [Required(ErrorMessage = "Укажите количество камер")]
        public int CountCameras { get; set; }
        /// <summary>
        /// толщина профиля
        /// </summary>
        [DisplayName("Толщина профиля")]
        [Required(ErrorMessage = "Укажите толщину профиля")]
        public int Thickness { get; set; }
        /// <summary>
        /// коэффициент теплосопротивления (R) (м² * °С / Вт)
        /// </summary>
        public double HeatResistanceCoefficient { get; set; }
    }
}
