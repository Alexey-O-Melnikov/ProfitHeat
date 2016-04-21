using System;
using System.Collections.Generic;

namespace ProfitHeat.Domain
{
    /// <summary>
    /// регион расположения
    /// </summary>
    public partial class Location
    {
        public int LocationID { get; set; }
        /// <summary>
        /// название
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// минимальная температура за 5 дней
        /// </summary>
        public int MinTemperature { get; set; }
    }
}
