using System.ComponentModel;

namespace ProfitHeat.Domain
{       
    /// <summary>
    /// производитель
    /// </summary>
    public class ManufacturerWindowProfile
    {
        public int ManufacturerWindowProfileID { get; set; }
        /// <summary>
        /// название компании
        /// </summary>
        [DisplayName("Производитель")]
        public string TitleCompany { get; set; }
    }
}