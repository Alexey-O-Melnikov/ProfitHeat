using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitHeat.Domain
{
    /// <summary>
    /// проект пользователя
    /// </summary>
	public class Project
	{
		public int ProjectID { get; set; }
        public int LocationID { get; set; }
        public int PlotID { get; set; }
        /// <summary>
        /// регион расположения
        /// </summary>
		public Location Location { get; set; }
        /// <summary>
        /// чертеж - схема
        /// </summary>
		public Plot Plot { get; set; }
        /// <summary>
        /// название проекта
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// дата/время создания
        /// </summary>
        public DateTime CreateDateTime { get; set; }
        /// <summary>
        /// комнаты
        /// </summary>
		public List<Room> Rooms { get; set; }
	}
}
