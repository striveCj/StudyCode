using Polly;
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
        #region 简单重试策略
        //public static int SaveChanges(this DbContext context,Action<IEnumerable> resolveConflicts,int retryCount=3)
        //{
        //    if (retryCount<=0)
        //    {
        //        throw new ArgumentOutOfRangeException(nameof(retryCount), $"{retryCount}必须大于0");
        //    }
        //    for (int retry = 1; retry < retryCount; retry++)
        //    {
        //        try
        //        {
        //            return context.SaveChanges();
        //        }
        //        catch (DbUpdateConcurrencyException exception)when(retry<retryCount)
        //        {
        //            resolveConflicts(exception.Entries);
        //        }
        //    }
        //    return context.SaveChanges();
        //}
        #endregion

        #region Polly重试策略
        public static int SaveChanges(this DbContext context, Action<IEnumerable> resolveConflicts, int retryCount = 3)
        {
            var retryPolicy = Policy.Handle<DbUpdateConcurrencyException>().Retry(retryCount, (ex, count) => {
                resolveConflicts(((DbUpdateConcurrencyException)ex).Entries);
            });
            return retryPolicy.Execute(context.SaveChanges);
        }
        #endregion

        #region 解决并发冲突
        public enum RefreshConflict
        {
            StoreWins,
            ClientWins,
            MergeClientAndStore
        }

        public static DbEntityEntry Refresh(this DbEntityEntry tracking,RefreshConflict refreshMode)
        {
            switch (refreshMode)
            {
                case RefreshConflict.StoreWins:
                    //当实体被删除时，重新加载，设置状态为Detached
                    tracking.Reload();
                    break;
                case RefreshConflict.ClientWins:
                    {
                        DbPropertyValues databaseValues = tracking.GetDatabaseValues();
                        if (databaseValues==null)
                        {
                            tracking.State = EntityState.Deleted;
                        }
                        else
                        {
                            tracking.OriginalValues.SetValues(databaseValues);
                        }
                        break;
                    }
               
                case RefreshConflict.MergeClientAndStore:
                    {
                        DbPropertyValues databaseValues = tracking.GetDatabaseValues();
                        if (databaseValues==null)
                        {
                            tracking.State = EntityState.Deleted;
                        }
                        else
                        {
                            DbPropertyValues originalValues = tracking.OriginalValues.Clone();
                            tracking.OriginalValues.SetValues(databaseValues);
                            databaseValues.PropertyNames.Where(property => !object.Equals(originalValues[property], databaseValues[property])).ToList().ForEach(property => tracking.Property(property).IsModified = false);
                        }
                        break;
                    }
            }
            return tracking;

        }

        //public static int SaveChanges(this DbContext context,RefreshConflict refreshMode,int retryCount=3)
        //{
        //    if (retryCount<=0)
        //    {
        //        throw new ArgumentOutOfRangeException($"{retryCount}必须大于0",nameof(retryCount));
        //    }
        //    return context.SaveChanges(conflicts => conflicts.ToList().ForEach(tracking => tracking.Refresh(refreshMode)), retryCount);

        //}

        //public static int SaveChanges(this DbContext context, RefreshConflict refreshMode) => context.SaveChanges(c => c.ToList().ForEach(tracking => tracking.Refresh(refreshMode)));
        #endregion
    }
}
