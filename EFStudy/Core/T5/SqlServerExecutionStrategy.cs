using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFStudy.Core.T5
{
    public class SqlServerExecutionStrategy : DbExecutionStrategy
    {
        public SqlServerExecutionStrategy() { }

        public SqlServerExecutionStrategy(int maxRetryCount,TimeSpan maxDelay):base(maxRetryCount,maxDelay)
        {

        }
        protected override bool ShouldRetryOn(Exception exception)
        {
            bool bRetry = false;
            if (exception is SqlException)
            {
                var objSqlException = (SqlException)exception;
                var lstErrorNumbersToRetry = new List<int>() { 5 };
                if (objSqlException.Errors.Cast<SqlError>().Any(A=>lstErrorNumbersToRetry.Contains(A.Number)))
                {
                    bRetry = true;
                }
            }
            return bRetry;
        }
    }
}
