using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
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
            //TODO:线程状态位于Thread对象的ThreadState属性中，ThreadState属性是一个C#枚举对象。
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

        public static void RunThreads()
        {
            var sample = new ThreadSample();
            var threadOne = new Thread(sample.CountNumbers);
            threadOne.Name = "ThreadOnde";
            var threadTwo = new Thread(sample.CountNumbers);
            threadTwo.Name = "ThreadTwo";
            threadOne.Priority = ThreadPriority.Highest;
            threadTwo.Priority = ThreadPriority.Lowest;
            threadOne.Start();
            threadTwo.Start();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            sample.Stop();
        }
        /// <summary>
        /// 线程优先级
        /// </summary>
        public static void ThreadsPriority()
        {
            Console.WriteLine("Current thread priority {0}", Thread.CurrentThread.Priority);
            Console.WriteLine("Running on all cores available");
            RunThreads();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.WriteLine("Running in a single core");
            Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(1);
            RunThreads();
        }

        /// <summary>
        /// 前台线程和后台线程
        /// </summary>

        public static void ThreadBeforeAfter()
        {
            var sampleForeground = new ThreadSample2(10);
            var sampleBackground = new ThreadSample2(20);

            var threadOne = new Thread(sampleBackground.CountNumbers) { Name = "ForegroundThread" };
            var threadTwo = new Thread(sampleBackground.CountNumbers)
            {
                Name = "BackgroundThread",
                IsBackground = true
            };
            threadOne.Start();
            threadTwo.Start();
        }

        static void Count(object iterations)
        {
            CountNumbers((int)iterations);
        }
        static void CountNumbers(int iterations)
        {
            for (int i = 0; i < iterations; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(0.5));
                Console.WriteLine("{0} prints {1}", Thread.CurrentThread.Name, i);
            }
        }
        static void PrintNumber(int number)
        {
            Console.WriteLine(number);
        }
        /// <summary>
        /// 向线程传递参数
        /// </summary>

        public static void PassingParametersThread()
        {
            var sample = new ThreadSample3(10);
            var threadOne = new Thread(sample.CountNumbers);
            threadOne.Name = "ThreadOnde";
            threadOne.Start();
            threadOne.Join();
            Console.WriteLine("-----------------------------");
            var threadTwo = new Thread(Count);
            threadTwo.Name = "ThreadTwo";
            threadTwo.Start(8);
            threadTwo.Join();
            Console.WriteLine("---------------------");
            var threadThree = new Thread(() => CountNumbers(12));
            threadThree.Name = "ThreadThree";
            threadThree.Start();
            threadThree.Join();
            Console.WriteLine("-------------------------------------");

            int i = 10;
            var threadFour = new Thread(() => PrintNumber(i));
            i = 20;
            var threadFive = new Thread(() => PrintNumber(i));
            threadFour.Start();
            threadFive.Start();
        }

        static void TestCounter(CounterBase c)
        {
            for (int i = 0; i < 100000; i++)
            {
                c.Increment();
                c.Decrement();
            }
        }
        /// <summary>
        /// 使用Lock关键字
        /// </summary>
        public static void ThreadLock()
        {
            Console.WriteLine("Incorrect counter");
            var c = new Counter();
            var t1 = new Thread(() => TestCounter(c));
            var t2 = new Thread(() => TestCounter(c));
            var t3 = new Thread(() => TestCounter(c));

            t1.Start();
            t2.Start();
            t3.Start();
            t1.Join();
            t2.Join();
            t3.Join();

            Console.WriteLine("Total count:{0}",c.Count);
            Console.WriteLine("============================");
            Console.WriteLine("Correct counter");

            var c1 = new CounterWithLock();

            t1 = new Thread(() => TestCounter(c1));
            t2 = new Thread(() => TestCounter(c1));
            t3 = new Thread(() => TestCounter(c1));
            t1.Start();
            t2.Start();
            t3.Start();
            t1.Join();
            t2.Join();
            t3.Join();
            Console.WriteLine("Total count:{0}", c.Count);
        }
    }
    abstract class CounterBase
    {
        public abstract void Increment();
        public abstract void Decrement();
    }

    class Counter : CounterBase {
        public int Count { get; private set; }
        public override void Increment()
        {
            Count++;
        }
        public override void Decrement()
        {
            Count--;
        }
    }

    class CounterWithLock : CounterBase
    {
        private readonly object _syncRoot = new object();
        public int Count { get;private set; }

        public override void Increment()
        {
            lock (_syncRoot)
            {
                Count++;
            }
        }
        public override void Decrement()
        {
            lock (_syncRoot)
            {
                Count--;
            }
        }
    }


    class ThreadSample
    {
        private bool _isStopped = false;

        public void Stop()
        {
            _isStopped = true;
        }

        public void CountNumbers()
        {
            long counter = 0;
            while (!_isStopped)
            {
                counter++;
            }
            Console.WriteLine("{0} with {1,11} priority has a count={2,13:N0}", Thread.CurrentThread.Name, Thread.CurrentThread.Priority, counter);
        }

    }

    class ThreadSample2
    {
        private readonly int _iterations;

        public ThreadSample2(int iterations)
        {
            _iterations = iterations;
        }

        public void CountNumbers()
        {
            for (int i = 0; i < _iterations; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(0.5));
                Console.WriteLine("{0} prints{1}", Thread.CurrentThread.Name, i);
            }
        }
    }

    class ThreadSample3{
        private readonly int _iterations;
        public ThreadSample3(int iterations)
        {
            _iterations = iterations;
        }
        public void CountNumbers()
        {
            for (int i = 1; i < _iterations; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(0.5));
                Console.WriteLine("{0} prints {1}",Thread.CurrentThread.Name,i);
                
            }
        }
    }
}
