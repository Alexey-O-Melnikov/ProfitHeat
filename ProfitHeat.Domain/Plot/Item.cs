namespace ProfitHeat.Domain
{
	public class Item
	{
		public int ItemID { get; set; }
        public int LayerID { get; set; }
        /// <summary>
        /// тип ограждающей конструкции
        /// </summary>
        public string Enclosure { get; set; }
        /// <summary>
        /// координата Х начала
        /// </summary>
		public int StartX { get; set; }
        /// <summary>
        /// координата Y начала
        /// </summary>
		public int StartY { get; set; }
        /// <summary>
        /// координата Х конца
        /// </summary>
		public int EndX { get; set; }
        /// <summary>
        /// координата Y конца
        /// </summary>
		public int EndY { get; set; }
    }
}