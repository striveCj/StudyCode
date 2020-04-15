using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp13
{
    public class SimpleMath
    {
        [return TupleElementNames(new string[] { "result","remainder"})]
        public static ValueTuple<int, int> Divide(int dividend, int divisor);
        public static (int result,int remainder) Divide(int dividend,int divisor)
        {
            int result = dividend / divisor;
            int remainder = dividend % divisor;
            return (result, remainder);
        }

    }
}
