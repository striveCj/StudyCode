using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //T3D5();
            //T3D6();
            //T3D7();
            //T3D8();
            //T3D10();
            //T3D12();
            //T3D13();
            T3D14();
        }
        public static void T2D1()
        {
            string welcomeText = "欢迎你";
            Console.WriteLine(welcomeText);
            Console.ReadKey();
        }
        public static void T3D1()
        {
            bool isOverSpeed = false;
            int speed = 80;
            isOverSpeed = speed > 100;
            if (isOverSpeed)
            {
                Console.WriteLine("你已超速，为了你的安全请减速");
            }
        }
        /// <summary>
        /// 描述string类型的不可变性
        /// </summary>
        public static void T3D2()
        {
            string welcomeText = "hello";
            welcomeText = "Hi";
            Console.WriteLine(welcomeText);
            Console.ReadKey();
        }
        /// <summary>
        /// 数组 引用类型
        /// TODO：数组下标超出会出现IndexOutOfRangeException异常
        /// </summary>
        public static void T3D5()
        {
            int[] array = new int[5];
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
            Console.ReadKey();
        }
        public static void T3D6()
        {
            Complex num1 = new Complex(1, 2);
            Complex num2 = new Complex(3, 4);
            Complex sum = num1 + num2;
            Console.WriteLine($"num1和为{num1}");
            Console.WriteLine($"num2和为{num2}");
            Console.WriteLine($"sum和{sum}");
            Console.ReadKey();
        }
        /// <summary>
        /// if 判断语句
        /// </summary>
        public static void T3D7()
        {
            bool condition = true;
            int x = 13;
            if (condition)
            {
                Console.WriteLine("条件为真");
            }
            else
            {
                Console.WriteLine("条件为假");
            }

            if (x < 5)
            {
                Console.WriteLine("x小于5");
            }
            else if (x < 10)
            {
                Console.WriteLine("x大于5小于10");
            }
            else if (x < 20)
            {
                Console.WriteLine("x大于10小于20");
            }
            Console.ReadKey();
        }
        /// <summary>
        /// switch 判断语句
        /// </summary>
        public static void T3D8()
        {
            int switchVar = 2;
            switch (switchVar)
            {
                case 0:
                case 1:
                    Console.WriteLine("常量为0或1");
                    break;
                case 2:
                    Console.WriteLine("常量为2");
                    break;
                default:
                    Console.WriteLine("默认情况");
                    break;
            }
            Console.ReadKey();
        }
        /// <summary>
        /// while 循环语句
        /// </summary>
        public static void T3D9()
        {
            int i = 0;
            while (i < 5)
            {
                Console.WriteLine($"i为{i}");
                i++;
            }
            Console.ReadKey();
        }
        public static void T3D10()
        {
            int i = 5;
            Console.WriteLine("while执行结果如下");
            while (i<5)
            {
                Console.WriteLine($"i为{i}");
                i++;
            }
            Console.WriteLine("do-while执行结果如下");
            do
            {
                Console.WriteLine($"i为{i}");
                i++;
            } while (i<5);
            Console.ReadKey();
        }
        /// <summary>
        /// for 循环语句
        /// </summary>
        public static void T3D11()
        {
            Console.WriteLine("代码参见T3D5");
            Console.ReadKey();
        }
        /// <summary>
        /// foreach 循环语句 
        /// TODO:必须实现IEnumerabla和IEnumerabla<T>
        /// </summary>
        public static void T3D12()
        {
            int[] array = new int[] { 0, 1, 1, 2, 3, 4 };
            Console.WriteLine("数组元素如下");
            foreach (var element in array)
            {
                Console.WriteLine(element);
            }
            Console.ReadKey();
        }
        /// <summary>
        /// 比较continue和break
        /// </summary>
        public static void T3D13()
        {
            Console.WriteLine("使用continue退出循环情况");
            for (int i = 0; i < 5; i++)
            {
                if (i==2)
                {
                    continue;
                }
                Console.WriteLine($"当前值为{i}");
            }
            Console.WriteLine("使用brerk退出循环情况");
            for (int i = 0; i < 5; i++)
            {
                if (i == 2)
                {
                    break;
                }
                Console.WriteLine($"当前值为{i}");
            }
            Console.ReadKey();
        }
        /// <summary>
        /// 比较continue和break
        /// </summary>
        public static void T3D14()
        {
            Console.WriteLine("使用brerk退出循环情况");
            for (int i = 0; i < 5; i++)
            {
                if (i == 2)
                {
                    break;
                }
                Console.WriteLine($"当前值为{i}");
            }
            Console.WriteLine("循环退出");
            Console.WriteLine("使用return退出循环情况");
            for (int i = 0; i < 5; i++)
            {
                if (i == 2)
                {
                    return;
                }
                Console.WriteLine($"当前值为{i}");
            }
            Console.ReadKey();
            Console.WriteLine("循环退出");
        }
    }
    /// <summary>
    /// T3D3 枚举 值类型
    /// TODO:枚举默认是int类型，我们可以通过“:”指定全新的整数值类型
    /// </summary>
    enum Gender :byte
    {
        Female,
        ale
    }
    /// <summary>
    /// T3D4 定义结构体 值类型 一般表示轻量级对象
    /// </summary>
    public struct Point
    {
        public int x;
        public int y;
        public Point(int px,int py)
        {
            x = px;
            y = py;
        }
    }
    /// <summary>
    /// T3D6 运算符重载
    /// </summary>
    public struct Complex
    {
        public int real;
        public int imaginary;
        public Complex(int real,int imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
        }
        /// <summary>
        /// + 运算符重载 重载关键字operator
        /// </summary>
        /// <param name="complex1"></param>
        /// <param name="complex2"></param>
        /// <returns></returns>
        public static Complex operator +(Complex complex1,Complex complex2)
        {
            //TODO:值类型都有无参构造函数
            Complex result = new Complex();
            result.real = complex1.real + complex2.real;
            result.imaginary = complex1.imaginary + complex2.imaginary;
            return result;
        }
        public override string ToString()
        {
            return $"{real}+{imaginary}i";
        }
    }
}
