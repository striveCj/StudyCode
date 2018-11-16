using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreStart.Core
{
    public interface ISoftDeleteBaseEntity
    {
        bool IsDeleted { get; set; }
    }
}
