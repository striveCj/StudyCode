using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsBook_Csharp.MementoPattern
{
    class Caretaker
    {
        private string state;
        public string State { get { return state; } set { state = value; } }
    }
}
