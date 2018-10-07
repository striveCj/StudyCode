using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFStudy.Core.T5
{
   public class CustomConfiguration:DbConfiguration
    {
        public CustomConfiguration()
        {
            DbInterception.Add(new SQLProfiler(@"D:\log.txt", 1));
        }
        public class EfDbContext : DbContext
        {
            public EfDbContext():base("name=ConnectionString")
            {
                DbInterception.Add(new SQLProfiler(@"D:\log.txt", 1));
            }
        }
    }
}
