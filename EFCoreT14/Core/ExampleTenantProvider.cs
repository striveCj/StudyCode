using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreT14.Core
{
    public class ExampleTenantProvider:ITenantProvider
    {
        public Guid GetTenantId()
        {
            return Guid.Parse("655151E1-369C-4129-912E-4C7828E1AD5F");
        }

    }
}
