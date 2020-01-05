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
            WindowsIdentity identity = ShowIdentityInformation();
            WindowsIdentity principal = ShowPrincipal(identity);
            ShowClaims(principal.Claims);
        }

        public static WindowsIdentity ShowIdentityInformation()
        {
            WindowsIdentity identity=WindowsIdentity.GetCurrent();
            if (identity==null)
            {
                Console.WriteLine("not a windows identity");
                return null;
            }
            Console.WriteLine(identity);
            Console.WriteLine(identity.Name);
            Console.WriteLine(identity.IsAuthenticated);
            Console.WriteLine(identity.AuthenticationType);
            Console.WriteLine(identity.IsAnonymous);
            Console.WriteLine(identity.AccessToken.DangerousGetHandle());
            return identity;
        }

        public static WindowsPrincipal ShowPrincipal(WindowsIdentity identity)
        {
            Console.WriteLine("Show principal information");
            WindowsPrincipal principal=new WindowsPrincipal(identity);
            if (principal==null)
            {
                Console.WriteLine("not a Windows Principal");
                return null;
            }
            Console.WriteLine($"Users?{principal.IsInRole(WindowsBuiltInRole.User)}");
            Console.WriteLine($"Administrator?{principal.IsInRole(WindowsBuiltInRole.Administrator)}");
            return principal;
        }
    }
}
