using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp13
{
    public class SimpleMath
    {

        public static (int result,int remainder) Divide(int dividend,int divisor)
        {
            int result = dividend / divisor;
            int remainder = dividend % divisor;
            return (result, remainder);
        }
        private static void UseALibrary()
        {
            var t = SimpleMath.Divide(5, 3);
            Console.WriteLine($"{t.result},{t.remainder}");
        }

        private static void TupleNames()
        {
            var t1 = Divide(9, 4);
            Console.WriteLine( $"{t1.result},{t1.remainder}");
            (int res, int rem) t2 = Divide(11, 3);
            Console.WriteLine($"{t2.res}{t2.rem}");

            var t3 = (res: t1.result, rem: t1.remainder);
            var t4 = (t1.result, t1.remainder);
            Console.WriteLine($"{t4.result},{t4.remainder}");
        }
    }
}
