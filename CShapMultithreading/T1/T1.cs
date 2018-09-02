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
    public static class  T1
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

    }
}
