using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreStart.Model
{
    public abstract class Payment
    {
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }

        public string Name { get; set; }
    }
}
