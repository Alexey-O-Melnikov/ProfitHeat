using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitHeat.Domain
{
    /// <summary>
    /// комната
    /// </summary>
    public class Room 
    {
        public int RoomID { get; set; }
        /// <summary>
        /// название
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// этаж
        /// </summary>
        public int Level { get; set; }
		/// <summary>
		/// тип комнаты
		/// </summary>
		public TypeRoom TypeRoom { get; set; }
        /// <summary>
        /// радиатор
        /// </summary>
        public Radiator Radiator { get; set; }
        /// <summary>
        /// ограждающие конструкции
        /// </summary>
        public List<Cladding> Claddings { get; set; }
		/// <summary>
		/// окна
		/// </summary>
		public List<Window> Windows { get; set; }
        ///// <summary>
        ///// добавочные потери теплоты (β)
        ///// </summary>
        //public double AdditionalHeatLoss { get; set; }
    }
}
