using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp13
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var r = new Resource())
            {
                r.Foo();
            }
        }
    }
}
