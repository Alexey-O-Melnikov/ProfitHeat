using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "Укажите производителя оконного профиля")]
        public string TitleCompany { get; set; }
    }
}