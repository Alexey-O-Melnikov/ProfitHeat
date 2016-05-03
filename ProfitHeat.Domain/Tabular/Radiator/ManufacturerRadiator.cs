using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProfitHeat.Domain
{
    /// <summary>
    /// компания производитель радиаторов
    /// </summary>
    public class ManufacturerRadiator
    {
        public int ManufacturerRadiatorID { get; set; }
        /// <summary>
        /// навание компании
        /// </summary>
        [DisplayName("Производитель")]
        [Required(ErrorMessage = "Укажите производителя радиатора")]
        public string TitleCompany { get; set; }
    }
}