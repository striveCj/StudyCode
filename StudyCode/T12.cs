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

        #region T12D3
        public void T12D3()
        {
            BoxedandUnboxed();
            Console.ReadKey();
        }

        private static void BoxedandUnboxed()
        {
            Nullable<int> nullable = 5;
            int? nullablewithoutvalue = null;

            Console.WriteLine($"获取不为null的可空类型的类型:{nullable.GetType()}");

            object obj = nullable;
            Console.WriteLine($"装箱后obj的类型{obj.GetType()}");
            int value = (int)obj;
            Console.WriteLine($"拆箱成非可空变量的情况{value}");

            nullable = (int?)obj;
            Console.WriteLine($"拆箱成非可空变量的情况{nullable}");
            obj = nullablewithoutvalue;
            Console.WriteLine($"对null的可空类型装箱后obj是否为null：{obj == null}");

            nullable = (int?)obj;
            Console.WriteLine($"一个没有值的可空类型装箱后，拆箱成可空变量是否为null：{0}");
        }
        #endregion

        #region T12D4

        delegate void VoteDelegate(string name);
        public void T12D4()
        {
            VoteDelegate votedelegate = new VoteDelegate(new Friend().Vote);
            votedelegate("SomeBody");

            VoteDelegate votedelegate2 = delegate (string nickname)
              {
                  Console.WriteLine($"昵称为：{nickname}也来投票了");
              };
            votedelegate2("EveryOne");
            Console.ReadKey();
        }
        public class Friend
        {
            public void Vote(string nickname)
            {
                Console.WriteLine($"昵称为{nickname}来投票了");
            }
        }

        #endregion

        #region T12D5
        delegate void ClosureDelegate();
        public void T12D5()
        {
            closureMethod();
            Console.ReadKey();
        }
        private static void closureMethod()
        {
            string outVariable = "外部变量";
            string capturedVariable = "被捕获的外部变量";
            ClosureDelegate closuredelegate = delegate
            {
                string localvariable = "匿名方法局部变量";
                Console.WriteLine(capturedVariable + " " + localvariable);
            };
            closuredelegate();
        }
        #endregion
    }



}
