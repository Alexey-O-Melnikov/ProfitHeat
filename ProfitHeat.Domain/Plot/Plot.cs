using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProfitHeat.Domain
{
	public class Plot
	{
        public int PlotID { get; set; }
        public int ProjectID { get; set; }
        /// <summary>
        /// роза ветров
        /// </summary>
        public string WindRose { get; set; }
		/// <summary>
		/// направление севера
		/// </summary>
		public string North { get; set; }
        /// <summary>
        /// слои
        /// </summary>
		public virtual List<Layer> Layers { get; set; }
    }
}