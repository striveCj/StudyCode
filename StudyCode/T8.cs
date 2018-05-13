using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCode
{
    public class T8
    {
        #region T8D1
        delegate void MyDelegate(int para1, int para2);

        void Add(int para1, int para2)
        {
            int sum = para1 + para2;
            Console.WriteLine($"两个数的和为{sum}");
        }

        private static void MyMethod(MyDelegate myDelegate)
        {
            myDelegate(1, 2);
        }
        /// <summary>
        /// 委托使用步骤：定义委托类型》声明委托变量》实例化委托》作为参数传递给方法》调用委托
        /// </summary>
        public void T8D1()
        {
            MyDelegate D;
            D = new MyDelegate(new T8().Add);
            MyMethod(D);
            Console.Read();
        }
        #endregion

        #region T8D2
        public void T8D2()
        {
            T8 t8 = new T8();
            t8.Greeting("张三", t8.ChineseGreeting);
            t8.Greeting("Jake", t8.EnglishGreeting);
            Console.ReadKey();
        }


        /// <summary>
        /// 不使用委托实现方法，扩展性差
        /// </summary>
        /// <param name="name"></param>
        /// <param name="language"></param>
        public void Greeting(string name,string language)
        {
            switch (language)
            {
                case "zh-cn":
                    ChineseGreeting(name);
                    break;
                case "en-us":
                    EnglishGreeting(name);
                    break;
                default:
                    EnglishGreeting(name);
                    break;
            }
        }
        /// <summary>
        /// 使用委托完成上述方法
        /// </summary>
        /// <param name="name"></param>
        public delegate void GreetingDelegate(string name);
        public void Greeting(string name,GreetingDelegate callback)
        {
            callback(name);
        }

        public void EnglishGreeting(string name)
        {
            Console.WriteLine("Hello, "+name);
        }

        public void ChineseGreeting(string name)
        {
            Console.WriteLine("你好,"+name);
        }
        #endregion

        #region T8D3
        //TODO:①使用delegate关键字定义委托类型
        delegate void D3Delegate(int para1, int para2);

        void D3Add(int para1, int para2)
        {
            int sum = para1 + para2;
            Console.WriteLine($"两个数的和为{sum}");
        }

        private static  void D3Method(D3Delegate d3Delegate)
        {
            //TODO：⑤使用Invoke显示调用委托
            d3Delegate.Invoke(1, 2);
        }
        /// <summary>
        /// 委托使用步骤：定义委托类型》声明委托变量》实例化委托》作为参数传递给方法》调用委托
        /// </summary>
        public void T8D3()
        {
            //TODO:②声明一个委托变量D
            D3Delegate D;
            //TODO：③实例化委托类型，传递方法可以为静态方法也可以为实例方法
            D = new D3Delegate(new T8().D3Add);
            //TODO：④将委托类型作为参数传给另一个方法
            D3Method(D);
            Console.Read();
        }
        #endregion

        #region T8D4

        public delegate void DelegateTest();
        /// <summary>
        /// 委托链
        /// </summary>
        public void T8D4()
        {
            //TODO:用静态方法实例化委托
            DelegateTest dtstatic = new DelegateTest(T8.Method1);
            DelegateTest dtinstance = new DelegateTest(new T8().Method2);
            //TODO：定义一个委托，初始化为null，即不代表任何方法
            DelegateTest delegatechain = null;
            //TODO:使用“+”符号链接委托，链接多个委托后形成委托链
            delegatechain += dtstatic;
            delegatechain += dtinstance;
            //TODO:使用“-”符号把委托从委托链中移除
            delegatechain -= dtstatic;
            //TODO:调用委托链
            delegatechain();


            Console.Read();
        }
        private static void Method1()
        {
            Console.WriteLine("这是静态方法");
        }
        private void Method2()
        {
            Console.WriteLine("这是实例方法");
        }
        #endregion
    }
}
