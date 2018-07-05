using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCode
{
    public class T13
    {
        #region T13D2
        /// <summary>
        /// 隐式类型
        /// </summary>
        public void T13D2()
        {
            //用var声明局部变量
            //TODO：使用隐式类型时有一些限制
            //TODO：被声明的变量是一个局部变量，不能为字段(包括静态字段和实例字段)
            //TODO：变量在声明是必须被初始化，因为编译器要根据变量的赋值来推断类型，如果未初始化，编译器也就无法完成推断，C#是静态语言，变量类型位置就会出现编译时错误
            //TODO：变量不能初始化为一个方法组，也不能为一个匿名函数。
            //TODO：变量不能初始化为null，因为null可以隐式的转化为任何引用类型或可空类型，编译器奖不能推断出该变量到底是什么类型。
            //TODO：不能用一个正在声明的变量来初始化隐式类型
            //TODO：不能用var来声明方法中的参数类型
            var stringvariable = "learning hard";
            //stringvariable = 2;
        }
        #endregion

        public void T13D3()
        {
            Person2 p = new Person2("LearningHard", 25);
            p.Weight = 60;
            p.Height = 170;

            //使用对象初始化器后
            Person2 p2 = new Person2() { Name = "LearningHard", Age = 25, Weight = 75, Height = 170 };
        }

        #region T13D4
         public void T13D4()
        {
            //定义匿名对象
            var person = new { Name = "LearningHard", Age = 25 };
            Console.WriteLine($"{person.Name}的年龄为{person.Age}");
            //定义匿名数组
            var personcollection = new[]
            {
                new { Name = "LearningHard1", Age = 25 },
                new { Name = "LearningHard2", Age = 26 },
                new { Name = "LearningHard3", Age = 27 }
            };
            int totalAge = 0;
            foreach (var item in personcollection)
            {
                //验证Age属性是强类型的int类型
                totalAge += item.Age;
            }
            Console.WriteLine("所有人年龄总和为"+totalAge);
            Console.ReadKey();
        }

        #endregion
    }
    #region T13D1
    /// <summary>
    /// 自动属性
    /// </summary>
    public class Person1
    {
        //使用自动实现的属性来定义属性
        //定义可读写属性
        public string Name { get; set; }
        //定义只读属性
        public int Age { get;private set; }
    }
    #endregion

    #region T13D3
    public class Person2
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }

        public int Height { get; set; }

        public Person2() : this("")
        {

        }
        public Person2(string name) : this(name,0)
        {

        }
        public Person2(string name,int age) : this(name, age,0)
        {

        }
        public Person2(string name, int age,int weight) : this(name, age, weight, 0)
        {

        }
        public Person2(string name, int age, int weight,int height) 
        {
            this.Name = name;
            this.Age = age;
            this.Weight = weight;
            this.Height = height;
        }
    }
    #endregion


}
