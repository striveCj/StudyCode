using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudyCode
{
    public class T19
    {
        #region 前后台线程
        public void T19D1()
        {
            Thread backThread = new Thread(Worker);//创建一个线程
            backThread.IsBackground = true;
            backThread.Start();
            Console.WriteLine("从主线程退出");
            //TODO:此时不会调用执行Worker方法，如果想执行，有一下两种方法
            //TODO：1.将所创建的线程设置为非后台线程，由于用Thread类创建的线程默认为前台线程，所以我们像解决方法1中那样注释调用backThread.IsBackground = true;即可
            //TODO: 2.使主线程在后台线程执行完后再执行，即使主线程也进入睡眠，且其睡眠的时间比后台线程更长
            //TODO: 3.我们还可以通过在主函数中调用Join函数的方法，确保主线程会在后台线程执行结束后才开始运行
        }
        /// <summary>
        /// 解决办法1
        /// </summary>
        public void T19D1Tips1()
        {
            Thread backThread = new Thread(Worker);//创建一个线程
            //backThread.IsBackground = true;
            backThread.Start();
            Console.WriteLine("从主线程退出");
        }
        /// <summary>
        /// 解决办法2
        /// </summary>
        public void T19D1Tips2()
        {
            Thread backThread = new Thread(Worker);//创建一个线程
            backThread.IsBackground = true;
            backThread.Start();
            Thread.Sleep(2000);
            Console.WriteLine("从主线程退出");
        }
        /// <summary>
        /// 解决办法3
        /// </summary>
        public void T19D1Tips3()
        {
            Thread backThread = new Thread(Worker);//创建一个线程
            backThread.IsBackground = true;
            backThread.Start();
            //TODO：此方法涉及线程同步的概念，在某些情况下，需要两个线程同步运行，即一个线程必须等待另一个线程借宿之后才能运行。
            backThread.Join();
            Console.WriteLine("从主线程退出");
        }
        public static void Worker()
        {
            Thread.Sleep(1000);
            Console.WriteLine("从后台线程退出");
        }
        public void T19D2()
        {
            Thread parmThread = new Thread(new ParameterizedThreadStart(Workers));
            parmThread.Name = "线程1";
            parmThread.Start("123");
            Console.WriteLine("从主线程返回");
        }
        public static void Workers(object data)
        {
            Thread.Sleep(1000);
            Console.WriteLine("传入的参数为"+data.ToString());
            Console.WriteLine("从线程1返回");
            Console.Read();
        }
        #endregion

        #region 线程的容器-线程池
        /// <summary>
        /// 通过线程池来实现多线程
        /// </summary>
        public void T19D3()
        {
            //TODO：要使用线程池中的线程，需要调用静态方法 ThreadPool.QueueUserWorkItem，以指定线程要调用的方法
            Console.WriteLine($"主线程ID={Thread.CurrentThread.ManagedThreadId}");
            ThreadPool.QueueUserWorkItem(CallBackWorkItem);
            ThreadPool.QueueUserWorkItem(CallBackWorkItem, "work");
            Thread.Sleep(3000);
            Console.WriteLine("主线程退出");
        }

        public static void CallBackWorkItem(object state)
        {
            Console.WriteLine("线程池开始执行");
            if (state!=null)
            {
                Console.WriteLine($"线程池线程ID={Thread.CurrentThread.ManagedThreadId}传入的参数为{state.ToString()}");
            }
            else
            {
                Console.WriteLine($"线程池线程ID={Thread.CurrentThread.ManagedThreadId}");
            }
        }
        #endregion
    }
}
