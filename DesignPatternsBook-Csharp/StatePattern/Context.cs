using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsBook_Csharp.StatePattern
{
    class Context
    {
        private State state;
        public Context(State state)
        {
            this.state = state;
        }

        public State State
        {
            get { return state; }
            set
            {
                state = value;
                Console.WriteLine("当前的状态："+state.GetType().Name);
            }
        }
        public void Request()
        {
            state.Handle(this);
        }
    }
}
