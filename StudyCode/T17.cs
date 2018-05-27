using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCode
{
    public class T17
    {
        #region T17D1
        public static void T17D1()
        {
            TestMethod(2, 4, "hello");
            TestMethod(2, 14);
            TestMethod(2);
            //命名参数
            TestMethod(2, name: "hi");
            Console.Read();
        }
        /// <summary>
        /// 带有可选参数的方法
        /// TODO:可选参数必须在必选参数之后，参数默认值必须为常量，参数数组不能为可选参数，ref或out不能为可选参数
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="name"></param>
        static void TestMethod(int x,int y=10,string name="JakeChen")
        {
            Console.WriteLine($"x={x}y={y}name={name}");
        }
        #endregion

        #region T17D2
        /// <summary>
        /// 协变性
        /// </summary>
        public static void T12D3()
        {
            //TODO：协变性是指泛型类型参数可以从一个派生类隐式的转化为基类
            List<object> listobject = new List<object>();
            List<string> liststrs = new List<string>();

            listobject.AddRange(liststrs);
            //liststrs.AddRange(listobject);
        }
        #endregion

        #region T17D3
        /// <summary>
        /// 协变性
        /// </summary>
        public void T17D3()
        {
            //TODO：协变性指的是泛型类型参数可以从一个基类隐式的转化为派生类
            List<object> listobject = new List<object>();
            List<string> liststrs = new List<string>();

            IComparer<object> objComparer = new TestComparer();
            IComparer<string> strComparer = new TestComparer();
            liststrs.Sort(objComparer);
            //listobject.Sort(strComparer);


        }
        public class TestComparer : IComparer<object>
        {
            public int Compare(object obj1,object obj2)
            {
                return obj1.ToString().CompareTo(obj2.ToString());
            }
        }
        #endregion

        #region 协变和逆变的注意事项
        //TODO: 只有接口和委托才支持协变和逆变(如Func<out TResult>,Action<in T>),累活泛型方法的类型参数都不支持协变和逆变。
        //TODO: 协变和逆变只试用与引用类型，值类型不支持协变和逆变(因为可变性存在引用转换的过程，而值类型变量存储的就是对象本身，并不是对象的引用)，所以List<int>无法转换为IEnumerable<object>
        //TODO：必须显示的用in或out来标记类型参数
        //TODO：委托的可变性不要在多播委托中使用
        #endregion
    }
}
