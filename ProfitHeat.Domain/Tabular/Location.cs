using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProfitHeat.Domain
{
    /// <summary>
    /// ������ ������������
    /// </summary>
    public class Location
    {
        public int LocationID { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        [DisplayName("�����")]
        [Required(ErrorMessage = "������� �����")]
        public string Title { get; set; }
        /// <summary>
        /// ����������� ����������� �� 5 ����
        /// </summary>
        public int MinTemperature { get; set; }
    }
}
