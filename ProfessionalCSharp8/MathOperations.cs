using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp8
{
    class MathOperations
    {
        public static void MultiplyByTwo(double value)
        {
         var res=   value * 2;
            Console.WriteLine(res);
        }

        public static void Square(double value)
        {
            var res = value * value;
            Console.WriteLine(res);

        }
    }
}
