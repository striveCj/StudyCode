using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("test");

        }

        void T3()
        {
            var myCustomer=new PhoneCustomer();
            myCustomer.FirstName = "Simon";//字段赋值
            var myCustomer2=new PhoneCustomerStruct();
        }
    }
}
