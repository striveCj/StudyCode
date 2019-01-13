using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreT14.Core
{
    public interface ITenantProvider
    {
        Guid GetTenantId();
    }
}
