using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFStudy.Core.T5
{
    public class SqlServerExecutionStrategy : DbExecutionStrategy
    {
        protected override bool ShouldRetryOn(Exception exception)
        {
            throw new NotImplementedException();
        }
    }
}
