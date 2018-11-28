using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreStart.Model
{
    public class CashPayment:Payment
    {

    }
    public class CreditcardPayment : Payment
    {
        public string CreditcardNumber { get; set; }
    }
}
