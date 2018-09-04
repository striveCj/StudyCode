using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CShapMultithreading.T1
{
    /// <summary>
    /// 线程基础
    /// </summary>
    public static class T1
    {
        //TODO:正在执行中的程序实例可被称为一个进程。进程由一个或多个线程组成。这意味着当运行程序时，始终有一个执行程序代码的主线程。

        public static void PrintNumbers()
        {
            Console.WriteLine("Starting...");
            for (int i = 1; i < 10; i++)
            {
                Console.WriteLine(i);
            }
        }
        public static void PrintNumbersWithDelay()
        {
            Console.WriteLine("StartinSleep...");
            for (int i = 1; i < 10; i++)
            {
                //线程休眠2秒
                Thread.Sleep(TimeSpan.FromSeconds(2));
                Console.WriteLine(i);
            }
        }
        /// <summary>
        /// 创建一个线程
        /// </summary>
        public static void T1ThreadStart()
        {
            //创建一个行程执行方法
            Thread t = new Thread(PrintNumbers);
            //线程开始执行
            t.Start();
            PrintNumbers();
        }
        /// <summary>
        /// 暂停线程
        /// </summary>
        public static void T1ThreadSleep()
        {
            Thread t = new Thread(PrintNumbersWithDelay);
            t.Start();
            PrintNumbers();
        }
        /// <summary>
        /// 线程等待
        /// </summary>
        public static void T1ThreadAwit()
        {
            Thread t = new Thread(PrintNumbersWithDelay);
            t.Start();
            //线程等待
            t.Join();
            Console.WriteLine("Thread completed");
        }
        /// <summary>
        /// 线程终结
        /// </summary>
        public static void T1ThreadEnd()
        {
            Console.WriteLine("Starting program...");
            Thread t = new Thread(PrintNumbersWithDelay);
            t.Start();
            Thread.Sleep(TimeSpan.FromSeconds(6));
            //给线程注入ThreadAbortException方法，导致线程终结
            t.Abort();
            Console.WriteLine("A thread has been aborted");
            Thread t1 = new Thread(PrintNumbers);
            t1.Start();
            PrintNumbers();
        }

        static void DoNothing()
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
        }
        static void PrintNumbersWithStatus()
        {
            Console.WriteLine("Starting...");
            Console.WriteLine(Thread.CurrentThread.ThreadState.ToString());
            for (int i = 1; i < 10; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
                Console.WriteLine(i);
            }
        }
        /// <summary>
        /// 检查线程状态
        /// </summary>
        public static void T1CheckThead()
        {
            //线程状态位于Thread对象的ThreadState属性中，ThreadState属性是一个C#枚举对象。
            Console.WriteLine("Starting...");
            Thread t = new Thread(PrintNumbersWithStatus);
            Thread t2 = new Thread(DoNothing);
            Console.WriteLine(t.ThreadState.ToString());
            t2.Start();
            t.Start();
            for (int i = 1; i < 30; i++)
            {
                Console.WriteLine(t.ThreadState.ToString());
            }
            Thread.Sleep(TimeSpan.FromSeconds(6));
            t.Abort();
            Console.WriteLine("A thread has been aborted");
            Console.WriteLine(t.ThreadState.ToString());
            Console.WriteLine(t2.ThreadState.ToString());
        }
    }
}
