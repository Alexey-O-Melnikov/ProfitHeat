using System.Collections.Generic;

namespace ProfitHeat.Domain
{
    public class Layer
    {
        public int LayerID { get; set; }
        public int PlotID { get; set; }
        /// <summary>
        /// номер слоя
        /// </summary>
        public int LayerNumber { get; set; }
        /// <summary>
        /// ограждающие конструкции
        /// </summary>
        public virtual List<Item> Items { get; set; }
    }
}