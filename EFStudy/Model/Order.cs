using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFStudy.Model
{
     public class Order
    {
        public int Id;
        public string Name;
        public class Address
        {
            public string Street;
            public string Region;
            public string Country;
        }
    }
}
