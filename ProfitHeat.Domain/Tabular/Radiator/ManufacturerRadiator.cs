using System.ComponentModel;

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
        public string TitleCompany { get; set; }
    }
}