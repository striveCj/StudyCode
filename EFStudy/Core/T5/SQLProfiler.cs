using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFStudy.Core.T5
{
    public class SQLProfiler:DbCommandInterceptor
    { private readonly string _logFile;
        private readonly int _executionTime;

        public SQLProfiler(string logFile,int executionTime)
        {
            _logFile = logFile;
            _executionTime = executionTime;
        }

        public override void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            base.ReaderExecuting(command, interceptionContext);
        }
        public override void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            base.ReaderExecuted(command, interceptionContext);
        }

        public override void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            base.NonQueryExecuting(command, interceptionContext);
        }

        public override void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            base.NonQueryExecuted(command, interceptionContext);
        }

        public override void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            base.ScalarExecuting(command, interceptionContext);
        }

        public override void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            base.ScalarExecuted(command, interceptionContext);
        }

        private void Executing<T>(DbCommandInterceptionContext<T> interceptionContext)
        {
            var timer = new Stopwatch();
            interceptionContext.UserState = timer;
            timer.Start();
        }

        private void Executed<T>(DbCommand command, DbCommandInterceptionContext<T> interceptionContext)
        {
            var timer = (Stopwatch)interceptionContext.UserState;
            timer.Stop();
            if (interceptionContext.Exception!=null)
            {
                File.AppendAllLines(
                    _logFile,
                    new string[]
                    {
                        "错误的SQL语句",
                        interceptionContext.Exception.Message,
                        command.CommandText,
                        Environment.StackTrace,
                        string.Empty,
                        string.Empty,
                    }
                );
            }
            else if (timer.ElapsedMilliseconds>=_executionTime)
            {
                File.AppendAllLines(_logFile, new string[] {
                    $"耗时SQL语句{timer.ElapsedMilliseconds}ms",
                    command.CommandText,
                    Environment.StackTrace,
                    string.Empty,
                    string.Empty
                });
            }
        }
    }
}
