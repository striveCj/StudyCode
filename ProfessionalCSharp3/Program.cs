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
            MathSapleText1();

            AC ac=new AC{X = 1};
            ChangeAC(ac);
            Console.WriteLine($"ac.x:{ac.X}");
            ChangeAC2(ref ac);
            Console.WriteLine($"ac.x:{ac.X}");
        }

        void T3()
        {
            var myCustomer=new PhoneCustomer();
            myCustomer.FirstName = "Simon";//字段赋值
            var myCustomer2=new PhoneCustomerStruct();
        }

        public static void MathSapleText1()
        {
            Console.WriteLine($"Pi is{Math.GetPi()}");
            int x = Math.GetSquareOf(5);
            Console.WriteLine($"Square of 5 is {x}");
            var math=new Math();
            math.Value = 30;
            Console.WriteLine($"Value field of math variable contains{math.Value}");
            Console.WriteLine($"Square of 30 is {math.GetSquare()}");
        }

        public static void ChangeAC(AC a)
        {
            a.X = 2;
        }
        public static void ChangeAC2(ref AC a)
        {
            a.X = 3;
        }
        public static void ChangeAS(AS a)
        {

        }
    }
}
