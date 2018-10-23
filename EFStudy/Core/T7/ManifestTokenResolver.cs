using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFStudy.Core.T7
{
    public class ManifestTokenResolver : IManifestTokenResolver
    {
        private  readonly  IManifestTokenResolver _defaultResolver=new DefaultManifestTokenResolver();
        public string ResolveManifestToken(DbConnection connection)
        {
            if (connection is SqlConnection)
            {
                return "2012";
            }
            else
            {
                return _defaultResolver.ResolveManifestToken(connection);
            }
        }
    }
}
