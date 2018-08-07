using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFStudy.Model
{
     public class CreditCard:BillingDetail
    {
        /// <summary>
        /// 信用卡类型
        /// </summary>
        public int CardType { get; set; }
        /// <summary>
        /// 信用卡失效月份
        /// </summary>
        public string ExpiryMonth { get; set; }
        /// <summary>
        /// 信用卡失效年份
        /// </summary>
        public string ExpiryYear { get; set; }
    }
}
