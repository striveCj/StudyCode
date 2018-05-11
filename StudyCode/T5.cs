using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCode
{
    public class T5
    {
        /// <summary>
        /// 子类初始化顺序调用
        /// </summary>
        public void T5D4()
        {
            ChildA child = new ChildA();
            child.Print();
            Console.Read();
        }
        /// <summary>
        /// 强制访问隐藏基类成员
        /// </summary>
        public void T5D5()
        {
            Horse horse = new Horse();
            horse.Eat();
            ((Animal)horse).Eat();
            Console.Read();
        }
    }
    /// <summary>
    /// T5D1 封装
    /// </summary>
    public class PersonNine
    {
        private string _name;
        private int _age;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Age
        {
            get { return _age; }
            set
            {
                if (value<0||value>120)
                {
                    throw new ArgumentOutOfRangeException("AgeIntPropery", value, "年龄必须在0-120之间");
                }
                _age = value;
            }
        }
    }
    /// <summary>
    /// T5D2 继承 动物基类
    /// TODO: abstract 抽象类 无法被实例化
    /// </summary>
    public abstract class Animal
    {
        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                if (value < 0 || value > 10)
                {
                    throw new ArgumentOutOfRangeException("AgeIntPropery", value, "年龄必须在0-10之间");
                }
                _age = value;
            }
        }
        /// <summary>
        /// T5D5 多态 虚方法 virtual
        /// </summary>
        public virtual void Voice()
        {
            Console.WriteLine("动物发出声音");
        }
        public void Eat()
        {
            Console.WriteLine("动物吃方法");
        }
    }
    /// <summary>
    /// T5D2 继承 马子类
    /// </summary>
    public class Horse : Animal
    {
        /// <summary>
        /// T5D5 多态 重写 override
        /// TODO:sealed 密封关键字 无法继承
        /// </summary>
        public sealed override void Voice()
        {
            base.Voice();
            Console.WriteLine("马发出嘶.......嘶的声音");
        }
        /// <summary>
        /// TODO：如果子类方法与基类方法同名，我们可以使用new关键字把基类隐藏
        /// </summary>
        public new void Eat()
        {
            Console.WriteLine("马吃方法");
        }
    }

    public class Test : Horse
    {
        //TODO:由于密封所以无法重写
        //public override void Voice()
        //{

        //}
    }
    /// <summary>
    /// T5D2 继承 羊子类
    /// </summary>
    public class Sheep : Animal
    {
        /// <summary>
        /// T5D5 多态 重写 override
        /// </summary>
        public override void Voice()
        {
            base.Voice();
            Console.WriteLine("羊发出咩.......咩的声音");
        }


    }
    /// <summary>
    /// T5D3 密封类
    /// </summary>
    public sealed class SealedClass
    {
        //TODO: 密封类不能作为其他类的基类
    }
    /// <summary>
    /// T5D4 子类的初始化顺序
    /// </summary>
    public class Parent
    {
        /// <summary>
        /// ②调用基类构造函数
        /// </summary>
        public Parent()
        {
            Console.WriteLine("基类构造函数被调用");
        }
    }
    public class ChildA : Parent
    {
        /// <summary>
        /// ①初始化它的实例字段
        /// </summary>
        private int FieldA = 3;
        /// <summary>
        /// ③调用子类构造函数
        /// </summary>
        public ChildA()
        {
            Console.WriteLine("子类构造函数被调用");
        }
        public void Print()
        {
            Console.WriteLine(FieldA);
        }
    }
}
