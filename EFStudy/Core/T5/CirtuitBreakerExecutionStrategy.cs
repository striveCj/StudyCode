using Polly;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EFStudy.Core.T5
{
    public class CirtuitBreakerExecutionStrategy : IDbExecutionStrategy
    {
        private Policy _policy;

        public CirtuitBreakerExecutionStrategy(Policy policy)
        {
            _policy = policy;
        }

        public bool RetriesOnFailure
        {
            get
            {
                return true;
            }
        }

        public void Execute(Action operation)
        {
            _policy.Execute(() => { operation.Invoke(); });
        }

        public TResult Execute<TResult>(Func<TResult> operation)
        {
            return _policy.Execute(() => { return operation.Invoke(); });
        }

        public async Task ExecuteAsync(Func<Task> operation, CancellationToken cancellationToken)
        {
            await _policy.ExecuteAsync(() => { return operation.Invoke(); });
        }

        public async Task<TResult> ExecuteAsync<TResult>(Func<Task<TResult>> operation, CancellationToken cancellationToken)
        {
            return await _policy.ExecuteAsync(() => { return operation.Invoke(); });
        }
    }
}
