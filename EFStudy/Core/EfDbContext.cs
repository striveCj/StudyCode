using EFStudy.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EFStudy.Model.Order;

using EFStudy.Conventions;
using System.Text.RegularExpressions;
using EFStudy.Attributes;
using System.Reflection;

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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.ComplexType<Address>();
            modelBuilder.Conventions.Add<CustomKeyConvention>();
            modelBuilder.Conventions.Add<DateTime2Convention>();
            //TODO: 利用Properties方法查找模型全局处理
            modelBuilder.Properties<decimal>().Configure(config => config.HasPrecision(10, 2));
            //TODO:对多个属性进行相同的约定配置时，最后一个约定将覆盖前面所有相同的约定
            modelBuilder.Properties<string>().Configure(c => c.HasMaxLength(500));
            modelBuilder.Properties<string>().Configure(c => c.HasMaxLength(250));
            //TODO:自定义类型约定
            modelBuilder.Types().Configure(c => c.ToTable(GetTableName(c.ClrType)));
            modelBuilder.Properties().Where(x => x.GetCustomAttributes(false).OfType<IsUnicode>().Any()).Configure(c => c.IsUnicode(c.ClrPropertyInfo.GetCustomAttribute<IsUnicode>().Unicode));
            //简化
            modelBuilder.Properties().Having(x => x.GetCustomAttributes(false).OfType<IsUnicode>().FirstOrDefault()).Configure((config, att) => config.IsUnicode(att.Unicode));
        }
        /// <summary>
        /// 自定义类型约定
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private string GetTableName(Type type)
        {
            var result = Regex.Replace(type.Name, ".[A-Z]", m => m.Value[0] + "_" + m.Value[1]);
            return result.ToLower();
        }
    }





}
