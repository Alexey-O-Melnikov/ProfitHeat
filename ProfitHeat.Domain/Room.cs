﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        public int ProjectID { get; set; }
        public int TypeRoomID { get; set; }
        public int RadiatorID { get; set; }
        /// <summary>
        /// тип комнаты
        /// </summary>
        public virtual TypeRoom TypeRoom { get; set; }
        /// <summary>
        /// радиатор
        /// </summary>
        public virtual Radiator Radiator { get; set; }
        /// <summary>
        /// название
        /// </summary>
        [DisplayName("Название комнаты")]
        [Required(ErrorMessage = "Укажите название комнаты")]
        public string Title { get; set; }
        /// <summary>
        /// этаж
        /// </summary>
        [DisplayName("Этаж")]
        [Required(ErrorMessage = "Укажите этаж")]
        public int Level { get; set; }
        /// <summary>
        /// ограждающие конструкции
        /// </summary>
        public virtual List<Cladding> Claddings { get; set; }
        /// <summary>
        /// окна
        /// </summary>
        [DisplayName("Окно")]
        public virtual List<Window> Windows { get; set; }
        ///// <summary>
        ///// добавочные потери теплоты (β)
        ///// </summary>
        //public double AdditionalHeatLoss { get; set; }
    }
}
