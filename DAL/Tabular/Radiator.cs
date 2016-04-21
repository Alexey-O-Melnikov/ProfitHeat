using System;
using System.Collections.Generic;
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
        /// <summary>
        /// тип радиатора
        /// </summary>
        public string RadiatorType { get; set; }
        /// <summary>
        /// материал радиатора
        /// </summary>
        public string Material { get; set; }
        /// <summary>
        /// мощность одной секции
        /// </summary>
        public int PowerSection { get; set; }
    }
}
