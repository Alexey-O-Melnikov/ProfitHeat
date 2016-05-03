using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProfitHeat.Domain
{
    /// <summary>
    /// материал радиатора
    /// </summary>
    public class MaterialRadiator
    {
        public int MaterialRadiatorID { get; set; }
        /// <summary>
        /// название материала радиатора
        /// </summary>
        [DisplayName("Материал радиатора")]
        [Required(ErrorMessage = "Укажите материал радиатора")]
        public string TitleMaterialRadiator { get; set; }
    }
}