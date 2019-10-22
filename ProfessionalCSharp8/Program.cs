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
            int x = 40;
            GetAString firstStringMethod=new GetAString(x.ToString);
            Console.WriteLine($"String is {firstStringMethod}");
        }

        private delegate string GetAString();
    }
}
