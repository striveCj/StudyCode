using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFStudy.Core.T7;

namespace EFStudy.Core
{
     public class DbContextConfiguration:DbConfiguration
    {
        public DbContextConfiguration()
        {
            //TODO:关闭数据库初始化
            SetDatabaseInitializer<EfDbContext>(null);
            //TODO:上下两种方式一个意思
            SetDatabaseInitializer<EfDbContext>(new NullDatabaseInitializer<EfDbContext>());
            //TODO:设置默认数据库版本查询
            SetManifestTokenResolver(new ManifestTokenResolver());
            DbInterception.Add(new NLogCommandInterceptor());
        }
    }
}
