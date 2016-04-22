namespace ProfitHeat.Domain
{
    public class WallLayer
    {
        public int WallLayerID { get; set; }
        public int CladdingID { get; set; }
        public int MaterialID { get; set; }
        /// <summary>
        /// материал
        /// </summary>
        public Material Material { get; set; }
        /// <summary>
        /// толщина
        /// </summary>
        public double Thickness { get; set; }
    }
}