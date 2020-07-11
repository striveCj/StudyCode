using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProfessionalCSharp211
{
    public class Calculator
    {
        private ManualResetEventSlim _mEvent;
        public int Result { get; private set; }

        public Calculator (ManualResetEventSlim ev)
        {
            _mEvent = ev;
        }

        public void Calculation(int x,int y)
        {
            Console.WriteLine(Task.CurrentId);
            Task.Delay(new Random().Next(3000)).Wait();
            Result = x + y;
            Console.WriteLine(Task.CurrentId);
            _mEvent.Set();
        }

        public void CalculatorMother()
        {
            const int taskCount = 4;
            var mEvents = new ManualResetEventSlim[taskCount];
            var waitHandles = new WaitHandle[taskCount];
            var calcs = new Calculator[taskCount];
            for (int i = 0; i < taskCount; i++)
            {
                int il = i;
                mEvents[i] = new ManualResetEventSlim(false);
                waitHandles[i] = mEvents[i].WaitHandle;
                calcs[i] = new Calculator(mEvents[i]);
                Task.Run(() => calcs[il].Calculation(il + 1, il + 3));
            }
        }

         public static IEnumerable<string> FillData(int size)
        {
            var r = new Random();
            return Enumerable.Range(0, size).Select(x => GetString(r));
        }

        private static string GetString(Random r)
        {
            var sb = new StringBuilder(6);
            for (int i = 0; i < 6; i++)
            {
                sb.Append((char)(r.Next(26) + 97));
            }
            return sb.ToString();
        }
    }
}
