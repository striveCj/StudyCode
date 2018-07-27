using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsBook_Csharp.MediatorPattern
{
    abstract class Mediator
    {
        public abstract void Send(string message, Colleague colleague);
    }
}
