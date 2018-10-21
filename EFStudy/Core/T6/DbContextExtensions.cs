using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFStudy.Core.T6
{
    /// <summary>
    /// 简单重试策略
    /// </summary>
    public static partial class DbContextExtensions
    {
        public static int SaveChanges(this DbContext context,Action<IEnumerable> resolveConflicts,int retryCount=3)
        {
            if (retryCount<=0)
            {
                throw new ArgumentOutOfRangeException(nameof(retryCount), $"{retryCount}必须大于0");
            }
            for (int retry = 1; retry < retryCount; retry++)
            {
                try
                {
                    return context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException exception)when(retry<retryCount)
                {
                    resolveConflicts(exception.Entries);
                }
            }
            return context.SaveChanges();
        }
    }
}
