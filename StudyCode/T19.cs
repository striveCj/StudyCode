using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        /// <summary>
        /// 协作式取消线程池线程
        /// </summary>
        public void T19D4()
        {
            Console.WriteLine("主线程运行");
            CancellationTokenSource cts = new CancellationTokenSource();
            ThreadPool.QueueUserWorkItem(callback, cts.Token);
            Console.WriteLine("按下回车建来取消操作");
            Console.Read();
            cts.Cancel();
            Console.ReadKey();
        }
        public static void callback(object state) {
            CancellationToken token = (CancellationToken)state;
            Console.WriteLine("开始计数");
            Count(token, 1000);
        }
        public static void Count(CancellationToken token,int countto)
        {
            for (int i = 0; i < countto; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("计数取消");
                    return;
                }
                Console.WriteLine("计数为"+i);
                Thread.Sleep(300);
            }
            Console.WriteLine("计数完成");
        }
        #endregion

        #region 线程同步
        static int tickets = 100;
        /// <summary>
        /// 多线程调用
        /// </summary>
        public void T19D5()
        {
            Thread thread1 = new Thread(SaleTicketThread1);
            Thread thread2 = new Thread(SaleTicketThread2);
            thread1.Start();
            thread2.Start();
            Thread.Sleep(4000);
        }
        private static void SaleTicketThread1()
        {
            while (true)
            {
                if (tickets>0)
                    Console.WriteLine("线程1出票"+tickets--);
                else
                    break;
            }
        }
        private static void SaleTicketThread2()
        {
            while (true)
            {
                if (tickets>0)
                    Console.WriteLine("线程2出票" + tickets--);
                else
                    break;
            }
        }
        /// <summary>
        /// 辅助对象
        /// </summary>
        static object gloalObj = new object();
        /// <summary>
        /// 使用见识器对象实现线程同步
        /// </summary>
        public void T19D6()
        {
            Thread thread1 = new Thread(SaleTicketThread3);
            Thread thread2 = new Thread(SaleTicketThread4);
            thread1.Start();
            thread2.Start();
        }
        private static void SaleTicketThread3()
        {
            while (true)
            {
                try
                {
                    //TODO: 在object对象上获得排他锁
                    Monitor.Enter(gloalObj);
                    Thread.Sleep(1);
                    while (true)
                    {
                        if (tickets > 0)
                            Console.WriteLine("线程1出票" + tickets--);
                        else
                            break;
                    }
                }
                finally
                {
                    //释放指定对象上的排他锁
                    Monitor.Exit(gloalObj);
                }
            }
        }
        private static void SaleTicketThread4()
        {
            while (true)
            {
                try
                {
                    //TODO: 在object对象上获得排他锁
                    Monitor.Enter(gloalObj);
                    Thread.Sleep(1);
                    while (true)
                    {
                        if (tickets > 0)
                            Console.WriteLine("线程2出票" + tickets--);
                        else
                            break;
                    }
                }
                finally
                {
                    //释放指定对象上的排他锁
                    Monitor.Exit(gloalObj);
                }
            }
        }
        /// <summary>
        /// 线程同步技术存在的问题
        /// </summary>
        public void T19D7()
        {
            int x = 0;
            const int iterationNumber = 5000000;
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < iterationNumber; i++)
            {
                x++;
            }
            Console.WriteLine($"不使用锁的情况下话费的时间：{sw.ElapsedMilliseconds}ms");
            sw.Restart();
            for (int i = 0; i < iterationNumber; i++)
            {
                Interlocked.Increment(ref x);
            }
            Console.WriteLine($"使用锁的情况下话费的时间：{sw.ElapsedMilliseconds}ms");
            Console.Read();
        }
        #endregion

        #region 总结
        //TODO: 在设计应用程序的时候应劲量避免使用线程同步，因为它会引起一些问题。
        //TODO: 它的使用比较繁琐。我们要用额外的代码把被多个线程同时访问的数据包围起来，并获取和释放线程的同步锁。如果在一个代码块处忘记获取锁，就有可能造成数据损坏
        //TODO: 使用线程同步会影响程序性能。因为获取和释放同步锁是需要时间的；并且在决定那个线程先获取锁的时候，CPU也必须进行协调。这些额外的工作多会对性能造成影响。
        //TODO: 线程同步每次只允许一个线程访问资源，这回导致线程阻塞。鸡儿系统会创建更多的线程，CPU也就要负担更繁重的调度工作。这个过程会对性能造成影响。
        #endregion
    }
}
