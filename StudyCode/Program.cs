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
            //T3D14();
            PersonThree p3 = new PersonThree();
            p3.Print("张三");
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
    /// <summary>
    /// T4D1 声明类
    /// </summary>
    public class Person
    {
        //TODO:如果使用readonly修饰字段则不需要在定义时初始化，可以在构造函数中再完成初始化，而使用const修饰则必须在定义时初始化
        private readonly string name;
        public const int age=18;
        protected bool sex;

    }
    /// <summary>
    /// T4D2 属性
    /// </summary>
    public class PersonTwo
    {
        private string _name;
        private static string _name2;
        private int _age;
        private bool _sex;
        private int _age2;
        public string Name
        {
           get { return _name; }
           set {//value是隐式参数
                _name = value; }
        }
        /// <summary>
        /// 只读属性不包含set访问器
        /// </summary>
        public int Age
        {
            get { return _age; }
        }
        /// <summary>
        /// 只写属性
        /// </summary>
        public bool Sex
        {
            private get { return _sex; }
            set { _sex = value; }
        }
        /// <summary>
        /// 增加逻辑控制的属性
        /// </summary>
        public int Age2
        {
            get { return _age2; }
            set
            {
                if (value<0||value>120)
                {
                    throw new ArgumentOutOfRangeException("AgeIntPropery", value, "年龄必须在0-120之间");
                }
                _age2 = value;
            }
        }
        /// <summary>
        /// 静态属性
        /// </summary>
        public static string Name2
        {
            get { return _name2; }
            set { _name2 = value; }
        }
    }
    /// <summary>
    /// T4D3 方法重载
    /// </summary>
    public class PersonThree
    {
        public void Print(string name)
        {
            Console.WriteLine("输入的值为:"+name);
        }
        public void Print(int age)
        {
            Console.WriteLine("输入的值为:" + age);
        }
        public void Print(string name,int age)
        {
            Console.WriteLine($"输入的值为:{name},{age}");
        }
    }
    /// <summary>
    /// T4D4 构造函数
    /// </summary>
    class PersonFour
    {
        //TODO：构造函数可以进行方法重载，构造函数不允许有返回值，构造函数必须和类同名
        //TODO:如果没有为类显示定义一个构造函数，C#编译器会自动生成一个函数体为空的无参实例构造函数
        private string _name;
        public string Name
        {
            get { return _name; }
        }
        public PersonFour()
        {
            _name = "Learning Hard";
        }
        public PersonFour(string name)
        {
            this._name = name;
        }
    }
    /// <summary>
    /// T4D5 私有构造函数单例模式
    /// </summary>
    class PersonFive
    {
        private string _name;
        public static PersonFive personFive;
        public string Name
        {
            get { return _name; }
        }

        private PersonFive()
        {
            Console.WriteLine("私有构造函数被调用");
            this._name = "Learning Hand";
        }
        public static PersonFive GetInstance()
        {
            personFive = new PersonFive();
            return personFive;
        }

    }

}
