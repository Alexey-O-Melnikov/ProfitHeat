namespace ProfitHeat.Domain
{
    /// <summary>
    /// слой ограждающей конструкции
    /// </summary>
    public class WallLayer
    {
        public int WallLayerID { get; set; }
        public int CladdingID { get; set; }
        public int MaterialID { get; set; }
        /// <summary>
        /// материал
        /// </summary>
        public virtual Material Material { get; set; }
        /// <summary>
        /// толщина
        /// </summary>
        public double Thickness { get; set; }
    }
}