﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public ApplicationUser ApplicationUser { get; set; }
        /// <summary>
        /// регион расположения
        /// </summary>
        public virtual Location Location { get; set; }
        /// <summary>
        /// название проекта
        /// </summary>
        [DisplayName("Название проекта")]
        [Required(ErrorMessage = "Укажите название проекта")]
        public string Title { get; set; }
        /// <summary>
        /// дата/время создания
        /// </summary>
        [DisplayName("Дата создания")]
        public DateTime CreateDateTime { get; set; }
        /// <summary>
        /// комнаты
        /// </summary>
		public virtual List<Room> Rooms { get; set; }
        /// <summary>
        /// слои
        /// </summary>
        public virtual List<Layer> Layers { get; set; }

    }
}
