using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProfitHeat.Domain
{
    /// <summary>
    /// регион расположения
    /// </summary>
    public class Location
    {
        public int LocationID { get; set; }
        /// <summary>
        /// название
        /// </summary>
        [DisplayName("Город")]
        [Required(ErrorMessage = "Укажите город")]
        public string Title { get; set; }
        /// <summary>
        /// минимальная температура за 5 дней
        /// </summary>
        public int MinTemperature { get; set; }
    }
}
