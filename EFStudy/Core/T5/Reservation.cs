using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFStudy.Core.T5
{
    public class Reservation
    {
        /// <summary>
        /// 预定Id
        /// </summary>
        public int BookingId { get; set; }
        /// <summary>
        /// 预订人
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 预定日期
        /// </summary>
        public DateTime BookingDate { get; set; }
    }
}
