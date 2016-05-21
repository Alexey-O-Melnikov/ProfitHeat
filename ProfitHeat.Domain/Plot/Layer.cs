using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProfitHeat.Domain
{
    public class Layer
    {
        public int LayerID { get; set; }
        public int ProjectID { get; set; }
        /// <summary>
        /// номер слоя
        /// </summary>
        public int LayerNumber { get; set; }
        /// <summary>
        /// ограждающие конструкции
        /// </summary>
        public List<Item> Items { get; set; }
    }
}