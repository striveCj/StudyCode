using Polly;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFStudy.Core.T5
{
    public class EFConfiguration:DbConfiguration
    {
        public Policy _policy;
        public EFConfiguration()
        {
            AddInterceptor(new StringTrimmerInterceptor());
            SetExecutionStrategy(SqlProviderServices.ProviderInvariantName, () => new SqlServerExecutionStrategy(3, TimeSpan.FromSeconds(60)));
            _policy = Policy.Handle<Exception>().CircuitBreaker(3, TimeSpan.FromSeconds(60));
            SetExecutionStrategy(SqlProviderServices.ProviderInvariantName, () => new CirtuitBreakerExecutionStrategy(_policy));
        }

        public class StringTrimmerInterceptor : IDbCommandTreeInterceptor
        {
            public void TreeCreated(DbCommandTreeInterceptionContext interceptionContext)
            {
                if (interceptionContext.OriginalResult.DataSpace==System.Data.Entity.Core.Metadata.Edm.DataSpace.SSpace)
                {
                    if (interceptionContext.Result is DbQueryCommandTree)
                    {
                        var queryCommand = (DbQueryCommandTree)interceptionContext.Result;
                        var newQuery = queryCommand.Query.Accept(new StringTrimmerQueryVisitor());
                        interceptionContext.Result = new DbQueryCommandTree(queryCommand.MetadataWorkspace, queryCommand.DataSpace, newQuery);
                    }
                }
            }
        }

        private class StringTrimmerQueryVisitor : DefaultExpressionVisitor
        {
            private static readonly string[] _typesToTrim = { "nvarchar", "varchar", "char", "nchar" };
            public override DbExpression Visit(DbNewInstanceExpression expression)
            {
                var arguments = expression.Arguments.Select(a =>
                {
                    if (a is DbPropertyExpression)
                    {
                        var propertyArg = (DbPropertyExpression)a;
                        if (_typesToTrim.Contains(propertyArg.Property.TypeUsage.EdmType.Name))
                        {
                            return EdmFunctions.Trim(a);
                        }
                    }
                     return a;
                });
            return DbExpressionBuilder.New(expression.ResultType,arguments);
            }
        
        }
    }
}
