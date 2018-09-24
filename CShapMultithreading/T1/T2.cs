using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CShapMultithreading.T1
{
    public class T2
    {
        static void TestCounter(CounterBase c)
        {
            for (int i = 0; i < 100000; i++)
            {
                c.Increment();
                c.Decrement();
            }
        }


        public void YzOption()
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
            Console.WriteLine("Total count :{0}", c.Count);
            Console.WriteLine("-—-—-—-—-—-—-—-—-—-—");
            Console.WriteLine("Correct counter");

            var c1 = new CounterNoLock();
            var t11 = new Thread(() => TestCounter(c1));
            var t21 = new Thread(() => TestCounter(c1));
            var t31 = new Thread(() => TestCounter(c1));
            t11.Start();
            t21.Start();
            t31.Start();
            t11.Join();
            t21.Join();
            t31.Join();
            Console.WriteLine("Total count :{0}", c1.Count);
        }
        public void test()
        {
            const string MutexName = "CSharpThreadingCookbook";
            using (var m = new Mutex(false, MutexName))
            {
                if (!m.WaitOne(TimeSpan.FromSeconds(5), false))
                {
                    Console.WriteLine("Second instance is running");
                }
                else
                {
                    Console.WriteLine("Running");

                    Console.ReadLine();
                    m.ReleaseMutex();
                }
            }
        }
        static SemaphoreSlim _semaphore = new SemaphoreSlim(4);

        static void AccessDatabase(string name, int seconds)
        {
            Console.WriteLine("{0}waits to access a database", name);
            _semaphore.Wait();


            Console.WriteLine("{0} was granted an access to a database ", name);
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
            Console.WriteLine("{0} is completed", name);
            _semaphore.Release();
        }
        public void SamaphoreSlim()
        {
            for (int i = 0; i <= 6; i++)
            {
                string threadName = "Thread" + i;
                int secondsToWait = 2 + 2 * i;
                var t = new Thread(() => AccessDatabase(threadName, secondsToWait));
                t.Start();
            }
        }

        private static AutoResetEvent _workerEvent = new AutoResetEvent(false);
        private static AutoResetEvent _mainEvent = new AutoResetEvent(false);

        static void Process(int seconds)
        {
            Console.WriteLine("Starting a long runing work...");
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
            Console.WriteLine("Work is done!");
            _workerEvent.Set();
            Console.WriteLine("Waiting for a main thread to complete");
            _mainEvent.WaitOne();
            Console.WriteLine("Starting second operation...");
            Thread.Sleep(TimeSpan.FromSeconds(5));
            _mainEvent.Set();
        }

        public void AutoResetEventClass()
        {
            var t = new Thread(() => Process(10));
            t.Start();
            Console.WriteLine("Waiting for another thread");
            _workerEvent.WaitOne();
            Console.WriteLine("First operation is completed");
            Console.WriteLine("Performing an operation on a main thread");
            Thread.Sleep(TimeSpan.FromSeconds(5));
            _mainEvent.Set();
            Console.WriteLine("Now Running the secon thread");
            _workerEvent.WaitOne();
            Console.WriteLine("second operation is complet!");

        }

        class CounterNoLock : CounterBase
        {
            private int _count;
            public int Count { get { return _count; } }
            public override void Increment()
            {
                Interlocked.Increment(ref _count);
            }

            public override void Decrement()
            {
                Interlocked.Decrement(ref _count);
            }


        }
    }
}
