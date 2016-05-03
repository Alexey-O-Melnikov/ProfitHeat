using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitHeat.Domain
{
    /// <summary>
    /// Стеклопакет
    /// </summary>
    public class Glass
    {
        public int GlassID { get; set; }
        /// <summary>
        /// тип стеклопакета
        /// </summary>
        [DisplayName("Тип стеклопакета")]
        public string Type { get; set; }
        /// <summary>
        /// количество камер
        /// </summary>
        [DisplayName("Количество стеклопакетов")]
        public int CountCamera { get; set; }
        /// <summary>
        /// pасстояние между стеклами
        /// </summary>
        [DisplayName("Расстояние между стеклами")]
        public int DistanceBetweenGlasses { get; set; }
        /// <summary>
        /// коэффициент теплосопротивления (R) (м² * °С / Вт)
        /// </summary>
        public double HeatResistanceCoefficient { get; set; }
    }
}
