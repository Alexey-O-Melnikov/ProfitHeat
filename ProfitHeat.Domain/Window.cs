using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitHeat.Domain
{
    /// <summary>
    /// Окно
    /// </summary>
    public class Window
	{
        public int WindowID { get; set; }
        public int RoomID { get; set; }
        public int GlassID { get; set; }
        public int WindowProfileID { get; set; }
        /// <summary>
        /// стеклопакет
        /// </summary>
        public Glass Glass { get; set; }
        /// <summary>
        /// оконный профиль
        /// </summary>
        public WindowProfile WindowProfile { get; set; }
        /// <summary>
        /// площадь окна
        /// </summary>
        public double WindowArea { get; set; }
        /// <summary>
        /// площадь стеклопакета
        /// </summary>
        public double GlassArea { get; set; }
    }
}
