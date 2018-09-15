﻿using EFStudy.Core;
using EFStudy.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFStudy
{
    class Program
    {
        static void Main(string[] args)
         {
            using (var efDbContext=new EfDbContext())
            {
                ChangeTracking(efDbContext);
                //SqlIsNull(efDbContext); 
                //SqlWhere(efDbContext);
                //QuerySql(efDbContext);
                //饥饿加载
                //var querycustomer = efDbContext.Customer.Include("Orders").FirstOrDefault();
                //var querycustomer = efDbContext.Customer.FirstOrDefault();
                //显示加载 
                //efDbContext.Entry(querycustomer).Collection(d => d.Orders).Load();
                //var queryOrders = querycustomer.Orders;
                //ModelAdded(efDbContext);
                //ModelUnChanged(efDbContext);
                //ModelModified(efDbContext);
                //ModelDeleted(efDbContext);
                //var student = new Student
                //{
                //    Name = "Jeffcky",
                //    Age = 26,
                //    CreatedTime = DateTime.Now,
                //    ModifiedTime = DateTime.Now,
                //    Courses = new List<Course>
                //    {
                //        new Course
                //        {
                //            Name="C#",
                //            MaximumStrength=12,
                //            CreatedTime=DateTime.Now,
                //            ModifiedTime=DateTime.Now
                //        },
                //        new Course
                //        {
                //            Name="EntityFrameWork6.X",
                //            MaximumStrength=12,
                //            CreatedTime=DateTime.Now,
                //            ModifiedTime=DateTime.Now
                //        }
                //    }

                //};
                //Course course = new Course
                //{
                //    Name = "WebApi",
                //    MaximumStrength = 12,
                //    CreatedTime = DateTime.Now,
                //    ModifiedTime = DateTime.Now,
                //    Students = new List<Student>
                //    {
                //        new Student
                //        {
                //            Name="Raviendra",
                //            Age=25,
                //            CreatedTime=DateTime.Now,
                //            ModifiedTime=DateTime.Now
                //        },
                //        new Student
                //        {
                //            Name="Pradeep",
                //            Age=25,
                //            CreatedTime=DateTime.Now,
                //            ModifiedTime=DateTime.Now
                //        }
                //    }

                //};
                //efDbContext.Student.Add(student);
                //efDbContext.SaveChanges();
                //var customer = new Customer
                //{
                //    Name = "chenjie",
                //    Email = "530216775@q.com",
                //    CreatedTime = DateTime.Now,
                //    ModifiedTime = DateTime.Now,
                //    Orders = new List<Order>
                //{
                //    new Order
                //    {
                //        Quanatity=12,
                //        Price=1500,
                //        CreatedTime=DateTime.Now,
                //    ModifiedTime=DateTime.Now
                //    },new Order
                //    {
                //        Quanatity=10,
                //        Price=2500,
                //        CreatedTime=DateTime.Now,
                //        ModifiedTime=DateTime.Now
                //    }
                //}
                //};
                //efDbContext.Customer.Add(customer);
                //efDbContext.SaveChanges();
                //efDbContext.Blogs.Add(new Model.Blog()
                //{
                //    Name = "陈杰",
                //    Url = "http://www.cnblogs.com/chen-jie"
                //});
                //efDbContext.SaveChanges();
                //var query = (from b in efDbContext.BullingDetails.OfType<BankAccount>() select b).ToList();

                //var users = new User
                //{
                //    BirthDate = DateTime.Now,
                //    CreatedTime = DateTime.Now,
                //    ModifiedTime = DateTime.Now,
                //    Name = "chenjie",
                //    IDNumber = "46031399108274789"
                //};
                //efDbContext.User.Add(users);
                //efDbContext.SaveChanges();

                //var user = efDbContext.User.Find(1);
                ////原始值
                //var originaValues = efDbContext.Entry(user).ComplexProperty(u => u.Address).OriginalValue;
                ////当前值
                //var currentValues = efDbContext.Entry(user).ComplexProperty(u => u.Address).CurrentValue;

            }
        }
        /// <summary>
        /// 不使用Add方法去添加实体(added)
        /// </summary>
        /// <param name="efContext"></param>
        public static void ModelAdded(EfDbContext efContext)
        {
            var customer = new Customer
            {
                Name = "chenjie",
                Email = "530216775@qq.com"
            };
            efContext.Entry(customer).State = System.Data.Entity.EntityState.Added;
            efContext.SaveChanges();
        }
        /// <summary>
        /// 附加追踪
        /// </summary>
        /// <param name="efContext"></param>
        public static void ModelUnChanged(EfDbContext efContext)
        {
            var customer = new Customer
            {
                Name = "chenjie",
                Email = "530216775@qq.com"
            };
            efContext.Customer.Attach(customer);
            efContext.Entry(customer).State= System.Data.Entity.EntityState.Unchanged;
            efContext.SaveChanges();
        }
        /// <summary>
        /// 修改操作
        /// </summary>
        /// <param name="efContext"></param>
        public static void ModelModified(EfDbContext efContext)
        {
            var customer = new Customer()
            {
                Id = 1,
                Name = "chenjie",
                CreatedTime = DateTime.Now,
                ModifiedTime = DateTime.Now
            };
            efContext.Entry(customer).State = System.Data.Entity.EntityState.Modified;
            efContext.SaveChanges();

        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="efContext"></param>
        public static void ModelDeleted(EfDbContext efContext)
        {
            var customer = new Customer()
            {
                Id = 1,
                Name = "chenjie",
                CreatedTime = DateTime.Now,
                ModifiedTime = DateTime.Now
            };
            efContext.Entry(customer).State = System.Data.Entity.EntityState.Deleted;
            efContext.SaveChanges();

        }

        public static void QuerySql(EfDbContext efContext)
        {
            //TODO:此方法查询的是上下文中的实体集合中的数据，实体会被上下文跟踪
            var customers = efContext.Customer.SqlQuery("select * from dbo.customers").ToList();
            //TODO:此方法查询的是在数据库上的实体不会被上下文跟踪
            var customer = efContext.Database.SqlQuery<Customer>("select * from dbo.customers").ToList();

            //TODO:使用SqlQuery方法查询时必须要返回所有列，否则会抛出异常
        }

        public static void SqlWhere(EfDbContext efContext)
        {
            efContext.Database.Log = Console.WriteLine;
            //TODO:通过导航属性过滤无效
            var orders = efContext.Orders.Where(d => d.Customer != null).ToList();
            //TODO:当有外键属性即映射关系是，通过导航属性查询被忽略
            var orderss = efContext.Orders.Where(d => d.CustomerId != 0).ToList();
        }
        /// <summary>
        /// 语义可空
        /// </summary>
        /// <param name="efContext"></param>
        public static void SqlIsNull(EfDbContext efContext)
        {
            efContext.Database.Log = Console.WriteLine;
            var orders = efContext.Orders.Where(d => d.Price==1);

            int price = 1;
            var orderss = efContext.Orders.Where(d => d.Price == price);

            int prices = 0;
            var ordersss = efContext.Orders.Where(d => d.Price == prices);
        }
        /// <summary>
        /// 变更追踪原理
        /// </summary>
        /// <param name="efContext"></param>
        public static void ChangeTracking(EfDbContext efContext)
        {
            //当我们将类中所有属性设置为virtual时，上下文中存在的就是POCO而是其派生类，此时实体总是被跟踪
            var entity = efContext.Set<Customer>().FirstOrDefault(d => d.Name == "ChenJie");
            Console.WriteLine(efContext.Entry(entity).State);
            entity.Name = "ChenJie";
            Console.WriteLine(efContext.Entry(entity).State);
        }

        public static void TrackingSimple(EfDbContext efContext)
        {
            efContext.Database.Log = Console.WriteLine;
            var watch = new Stopwatch();
            watch.Start();
            efContext.Set<SimpleClass>().ToList().ForEach(d =>
            {
                var pro1 = d.Property1;
                d.Property1 = d.Property2;
                d.Property2 = pro1;

                var prop3 = d.Property3;
                d.Property3 = d.Property4;
                d.Property4 = prop3;
            });
            efContext.SaveChanges();
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
        }
    }
}
