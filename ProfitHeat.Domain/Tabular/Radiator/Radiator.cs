using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitHeat.Domain
{
    /// <summary>
    /// радиатор
    /// </summary>
    public class Radiator
    {
        public int RadiatorID { get; set; }
        public int ManufacturerRadiatorID { get; set; }
        public int MaterialRadiatorID { get; set; }
        /// <summary>
        /// компания производитель радиаторов
        /// </summary>
        public virtual ManufacturerRadiator ManufacturerRadiator { get; set; }
        /// <summary>
        /// материал радиатора
        /// </summary>
        public virtual MaterialRadiator Material { get; set; }
        /// <summary>
        /// название модели
        /// </summary>
        [DisplayName("Модель")]
        public string TitleModel { get; set; }
        /// <summary>
        /// мощность одной секции
        /// </summary>
        [DisplayName("Мощность одной секции")]
        public int ThermalPower { get; set; }
    }
}
