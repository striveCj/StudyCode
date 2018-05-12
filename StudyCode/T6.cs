using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCode
{
    /// <summary>
    /// T6D1 定义接口
    /// </summary>
    interface ICustomCompare
    {
        //TODO: 接口中定义方法默认是public，且不能修改
        int CompareTo(object other);
    }
    public class T6:ICustomCompare
    {
        int _age;
        int Age
        {
            get { return _age; }
            set { _age = value; }
        }
        /// <summary>
        /// TODO:继承接口必须实现接口中的所有方法
        /// T6D2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int CompareTo(object value)
        {
            if (value==null)
            {
                return 1;
            }

            T6 otherp = (T6)value;
            if (this.Age<otherp.Age)
            {
                return -1;
            }
            if (this.Age>otherp.Age)
            {
                return 1;
            }
            return 0;
        }

        public void T6D3()
        {
            T6 t1 = new T6();
            t1.Age = 18;
            T6 t2 = new T6();
            t2.Age = 19;
            if (t1.CompareTo(t2)>0)
            {
                Console.WriteLine("t1比t2大");
            }
            else if (t1.CompareTo(t2)< 0)
            {
                Console.WriteLine("t1比t2小");
            }
            else
            {
                Console.WriteLine("t1和t2一样大");
            }
        }
    }
    /// <summary>
    /// T6D4  显示实现接口
    /// </summary>
    interface IChineseGreeting
    {
        void SayHello();
    }
    interface IAmericamGreeting
    {
        void SayHello();
    }
    public class Speaker : IChineseGreeting, IAmericamGreeting
    {
        void IChineseGreeting.SayHello()
        {
            Console.WriteLine("你好");
        }
        void IAmericamGreeting.SayHello()
        {
            Console.WriteLine("Hello");
        }
    }
}
