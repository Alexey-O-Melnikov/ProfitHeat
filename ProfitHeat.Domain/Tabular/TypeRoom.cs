﻿namespace ProfitHeat.Domain
{
    /// <summary>
    /// тип комнаты
    /// </summary>
    public class TypeRoom
    {
        public int TypeRoomID { get; set; }
        /// <summary>
        /// наименование типа комнаты
        /// </summary>
        public string TitleTypeRoom { get; set; }
        /// <summary>
        /// комфортная температура
        /// </summary>
        public int ComfortableTemperature { get; set; }
        /// <summary>
        /// воздухообмен
        /// </summary>
        public int? AirChange { get; set; }
    }
}