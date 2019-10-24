using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp8
{
    class Program
    {
        static void Main(string[] args)
        {
            //int x = 40;
            //GetAString firstStringMethod=new GetAString(x.ToString);
            //Console.WriteLine($"String is {firstStringMethod}");

            int x = 40;
            GetAString firstStringMethod = x.ToString;
            Console.WriteLine($"{firstStringMethod}");
            var balance=new Currency(34,50);
            firstStringMethod = balance.ToString;
            Console.WriteLine($"{firstStringMethod}");
            firstStringMethod=new GetAString(Currency.GetCurrencyUnit);
            Console.WriteLine($"{firstStringMethod}");
        }

        private delegate string GetAString();
    }
}
