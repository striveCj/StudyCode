using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFCoreStart.Core
{
    public class NoDIEFCoreDbContext:DbContext
    {
        public NoDIEFCoreDbContext(DbContextOptions options):base(options)
        {
            
        }
    }
}
