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

        private static void LogBarrierInformation(string info,Barrier barrier) {
            Console.WriteLine(Task.CurrentId);
            Console.WriteLine(barrier.ParticipantCount);
            Console.WriteLine(barrier.ParticipantsRemaining);
            Console.WriteLine(barrier.CurrentPhaseNumber);
        }

        private static void CalculationInTask(int jobNumber,int partitionSize,Barrier barrier,IList<string>[] coll,int loops,int[][] results)
        {
            LogBarrierInformation("CalculationInTask", barrier);
            for (int i = 0; i < loops; i++)
            {
                var data = new List<string>(coll[i]);
                int start = jobNumber * partitionSize;
                int end = start + partitionSize;
                Console.WriteLine(Task.CurrentId);
                Console.WriteLine(start);
                Console.WriteLine(end);
                for (int j = 0; j < end; j++)
                {
                    char c = data[j][0];
                    results[i][c - 97]++;
                }
                Console.WriteLine(Task.CurrentId);
                LogBarrierInformation("sending signal and wait", barrier);
                barrier.SignalAndWait();
                LogBarrierInformation("waiting completed", barrier);
            }
            barrier.RemoveParticipant();
            LogBarrierInformation("finished task removed", barrier);
        }
    }
}
