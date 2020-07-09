using System;
using System.Collections.Generic;
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
    }
}
