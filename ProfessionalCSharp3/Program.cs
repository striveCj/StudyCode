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

            //out
            string input1 = Console.ReadLine();
            int result1 = int.Parse(input1);
            Console.WriteLine($"result1{result1}");

            string input2 = Console.ReadLine();
            if (int.TryParse(input2, out int result2 ))
            {
                Console.WriteLine($"result2{result2}");
            }
            else
            {
                Console.WriteLine("not a number");
            }

            Color c1 = Color.Red;
            Console.WriteLine(c1);
            Color c2 = (Color) 2;
            short number = (short) c2;
            Console.WriteLine(number);
            DaysOfWeek mondayandWednesday = DaysOfWeek.Monday | DaysOfWeek.Wednesday;
            Console.WriteLine(mondayandWednesday);
            DaysOfWeek weekend = DaysOfWeek.Saturday | DaysOfWeek.Sunday;
            Console.WriteLine(weekend);

            Color red;
            if (Enum.TryParse<Color>("Red",out red))
            {
                Console.WriteLine($"successfully parsed {red}");
            }
            foreach (var day in Enum.GetNames(typeof(Color)))
            {
                Console.WriteLine(day);
            }
            
        }

        void T3()
        {
            var myCustomer=new PhoneCustomer();
            myCustomer.FirstName = "Simon";//字段赋值
            var myCustomer2=new PhoneCustomerStruct();
        }

        public static void CantChange(AValueType a)
        {
            Console.WriteLine(a.Data);
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

        public struct AValueType
        {
            public int Data;
        }

      
    }
}
