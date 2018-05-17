using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCode
{
    public class T12
    {
        #region T12D1
        public void T12D1()
        {
            Nullable<int> value = 1;
            Console.WriteLine("可控类型有值的输出情况");
            Display(value);

            value = new Nullable<int>();
            Console.WriteLine("可空类型没有值输出的情况：");
            Display(value);
        }

        private static void Display(int? nullable)
        {
            Console.WriteLine($"可空类型是否有值{nullable.HasValue}");
            if (nullable.HasValue)
            {
                Console.WriteLine($"值为{nullable.Value}");
            }
            Console.WriteLine($"GetValueorDefault():{nullable.GetValueOrDefault()}");

            Console.WriteLine($"GetValueOrDefault()重载方法{nullable.GetValueOrDefault(2)}");
            Console.WriteLine($"GetHashCode()方法调用{nullable.GetHashCode()}");
        }
        #endregion

        #region T12D2

        public void T12D2()
        {
            Console.WriteLine("??运算符");
            NullcoalescingOperator();
            Console.ReadKey();
        }
        private static void NullcoalescingOperator()
        {
            int? nullable = null;
            int? nullhasvalue = 1;
            int x = nullable ?? 12;

            int y = nullhasvalue ?? 123;
            Console.WriteLine(x);
            Console.WriteLine(y);

            string strnotnull = "123";
            string strnull = null;

            string result = strnotnull ?? "456";
            string result2 = strnull ?? "12";
            Console.WriteLine(result);
            Console.WriteLine(result2);
        }
        #endregion

    }

}
