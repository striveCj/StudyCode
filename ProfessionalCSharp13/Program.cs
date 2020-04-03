using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp13
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var r = new Resource())
            {
                r.Foo();
            }
        }

        private static void IntroWithLambadExpression()
        {
            Func<int, int, int> add = (x, y) => { return x + y; };
            int result = add(37, 5);
            Console.WriteLine(result);
        }

        private static void IntroWithLocalFunctions()
        {
            int add(int x,int y)
            {
                return x + y;
            }
            int result = add(37, 5);
            Console.WriteLine(result);
        }
    }
}
