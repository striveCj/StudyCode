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
            var t1 = new Thread(()=>TestCounter(c));
            var t2 = new Thread(() => TestCounter(c));
            var t3 = new Thread(() => TestCounter(c));
            t1.Start();
            t2.Start();
            t3.Start();
            t1.Join();
            t2.Join();
            t3.Join();
            Console.WriteLine("Total count :{0}",c.Count);
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
