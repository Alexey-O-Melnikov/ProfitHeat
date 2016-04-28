using System;
using System.Collections.Generic;

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
        public string Title { get; set; }
        /// <summary>
        /// ����������� ����������� �� 5 ����
        /// </summary>
        public int MinTemperature { get; set; }
    }
}
