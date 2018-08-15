using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFStudy.Model
{
    public class Order:BaseEntity
    {
        public byte Quanatity { get; set; }
        public int Price { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer  { get;set;}
    }
}
