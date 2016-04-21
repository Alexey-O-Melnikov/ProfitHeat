using System.Collections.Generic;

namespace ProfitHeat.Domain
{
	public class Plot
	{
		public int PlotID { get; set; }
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
		public List<Layer> Layers { get; set; }
	}
}