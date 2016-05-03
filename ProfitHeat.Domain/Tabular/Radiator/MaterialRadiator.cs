using System.ComponentModel;

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
        public string TitleMaterialRadiator { get; set; }
    }
}