using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.DesignerServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp24
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        public static WindowsIdentity ShowIdentityInformation()
        {
            WindowsIdentity identity=WindowsIdentity.GetCurrent();
            if (identity==null)
            {
                Console.WriteLine("not a windows identity");
                return null;
            }
        }
    }
}
