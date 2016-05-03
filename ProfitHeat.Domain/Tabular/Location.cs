using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ProfitHeat.Domain
{
    /// <summary>
    /// регион расположени€
    /// </summary>
    public class Location
    {
        public int LocationID { get; set; }
        /// <summary>
        /// название
        /// </summary>
        [DisplayName("√ород")]
        public string Title { get; set; }
        /// <summary>
        /// минимальна€ температура за 5 дней
        /// </summary>
        public int MinTemperature { get; set; }
    }
}
