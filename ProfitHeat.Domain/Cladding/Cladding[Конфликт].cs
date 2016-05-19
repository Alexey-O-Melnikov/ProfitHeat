using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitHeat.Domain
{
    /// <summary>
    /// Ограждаюжая конструкция
    /// </summary>
    public abstract class Cladding
    {
        public int CladdingID { get; set; }
        public int RoomID { get; set; }
        /// <summary>
        /// площадь
        /// </summary>
        public double Area { get; set; }
        /// <summary>
        /// материалы
        /// </summary>
        public List<WallLayer> WallLayers { get; set; }
        ///// <summary>
        ///// коэффициент уменьшения разности температур (n)
        ///// </summary>
        //public double ReduceTemperatureDifferenceCoefficient { get; set; }
        ///// <summary>
        ///// коэффициент теплоотдачи внутренний (α_вн)
        ///// </summary>
        //public double HeatIrradiationCoefficientIn { get; set; }
        ///// <summary>
        ///// коэффициент теплоотдачи внешний (α_н)
        ///// </summary>
        //public double HeatIrradiationCoefficientOut { get; set; }
        ///// <summary>
        ///// коэффициент теплосопротивления (R) (м² * °С / Вт)
        ///// </summary>
        //public double HeatResistanceCoefficient { get; set; }
    }
}
