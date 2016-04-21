namespace ProfitHeat.Domain
{
    /// <summary>
    /// материал
    /// </summary>
    public class Material
    {
        public int MaterialID { get; set; }
        /// <summary>
        /// название материала
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// толщина
        /// </summary>
        public double Thickness { get; set; }
        /// <summary>
        /// коэффициент теплопроводности (λ) (Вт / (м * °С))
        /// </summary>
        public double HeatConductivityCoefficient { get; set; }
    }
}