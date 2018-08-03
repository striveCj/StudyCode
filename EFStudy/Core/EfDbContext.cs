using EFStudy.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFStudy.Core
{
    public class EfDbContext:DbContext
    {
        public EfDbContext():base("name=ConnectionString")
        {
            //禁用数据库初始化策略
            Database.SetInitializer<EfDbContext>(null);
            //如果数据库不存在，就创建
            //Database.SetInitializer(new CreateDatabaseIfNotExists<EfDbContext>());
            //总是创建数据库，无论是否存在
            //Database.SetInitializer(new DropCreateDatabaseAlways<EfDbContext>());
            //如果EF检测到数据模型发生了改变，将更新模型
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EfDbContext>());
        }
        public DbSet<Blog> Blogs { get; set; }

       
    }
    public class Department
    {
        public int DepartmentID { get; set; }
        public string Name { get; set; }
    }

    public class StudentAddress
    {
        public int AddressId { get; set; }

        public int StudentId { get; set; }
    }
}
