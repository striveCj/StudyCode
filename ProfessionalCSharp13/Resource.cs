using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp13
{
    public class Resource:IDisposable
    {
        public void Foo() => Console.WriteLine("Foo");

        private bool disposeValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposeValue)
            {
                if (disposing)
                {
                    Console.WriteLine("release resource");
                }
                disposeValue = true;
            }
        }

        public void Dispose() => Dispose(true);
    }


}
