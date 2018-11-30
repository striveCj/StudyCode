using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreStart.Core;
using EFCoreStart.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace EFCoreStart
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new EFCoreDbContext())
            {
                //TODO:EFCode不知道是否要创建，所以要手动去创建   
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();

                //TODO:手动调用EntityFramework Core内置API创建
                //RelationalDatabaseCreator databaseCreator =
                //    (RelationalDatabaseCreator) context.Database.GetService<IDatabaseCreator>();
                //databaseCreator.CreateTables();
                //var student = context.Students.FirstOrDefault();

                //var s = new Student()
                //{
                //    Age = 1,
                //    Decimal = 1,
                //    Double = 1,
                //    Float = 1,
                //    CreateTime = DateTime.Now,
                //    Name = "chenjie"
                //};
                //context.Students.Add(s);
                //context.SaveChanges();

                //s.Name = "chenjielove";
                //context.SaveChanges();

                //context.Set<Customer>().AddRange(
                //    new Customer() { Name = "111"},
                //    new Customer() { Name = "222"}
                //    );
                //context.SaveChanges();


                //context.Blogs.Add(new Blog("http://www.cnblogs.com") {Name = "chenjie"});
                //context.SaveChanges();
                //foreach (var blog in context.Blogs)
                //{
                //    Console.WriteLine($"{blog.Id}{blog.Name}{blog.Url}");
                //}

                //var student=new Student()
                //{
                //    Age=1,
                //    Name = "chenjie",
                //    CreateTime = DateTime.Now
                //};
                //var course=new Course()
                //{
                //    Name = "EntityFramework Core",
                //    Introduce = "轻量级、可扩展、跨平台",
                //    CreatedTime = DateTime.Now
                //};
                //student.AddCourse(course);
                //context.Students.Add(student);
                //context.SaveChanges();

                //var courses = context.Set<Course>().Where(d => EF.Property<int>(d, "StudentId") == 1).ToList();
                //var course=new Course
                //{
                //    Introduce = "EntityFramework Core 2.0",
                //    Name = "EF Core"
                //};
                //context.Entry(course).Property("CreateTime").CurrentValue = DateTime.Now;
                //context.SaveChanges();
                //var blogs = context.Blogs.Include(d => d.Post).ToList();

                //var blog = context.Blogs.Include(d => d.Post).IgnoreQueryFilters().AsNoTracking().ToList();
                //var blogId = 1;
                //var posts = context.Set<Post>().Where(d => EF.Property<int>(d, "BlogId") == blogId);
                //var tags = new[]
                //{
                //    new Tag{Text="1"},
                //    new Tag{Text="2"},
                //    new Tag{Text="3"},
                //    new Tag{Text="4"},
                //    new Tag{Text="5"},
                //};
                //var posts = new[]
                //{
                //    new Post{Name="1"},
                //    new Post{Name="2"},
                //    new Post{Name="3"},
                //    new Post{Name="4"},
                //    new Post{Name="5"},
                //};

                //context.AddRange(new PostTag { Posts = posts[0], Tags = tags[0] },
                //    new PostTag { Posts = posts[1], Tags = tags[1] },
                //    new PostTag { Posts = posts[2], Tags = tags[2] },
                //    new PostTag { Posts = posts[3], Tags = tags[3] },
                //    new PostTag { Posts = posts[4], Tags = tags[4] });
                //context.SaveChanges();

                //var postss = context.Set<Post>().Include("PostTags.Tag").ToList();

                //context.Payments.Add(new CashPayment {Amount = 2M, Name = "Tom"});
                //context.Payments.Add(new CashPayment {Amount = 1000M, Name = "Jim"});

                //context.Payments.Add(new CreditcardPayment()
                //{
                //    Amount = 200000,
                //    Name = "招商银行",
                //    CreditcardNumber = "041647181912"
                //});
                //context.SaveChanges();

                //var payments = context.Payments.ToList();
                //foreach (var payment in payments)
                //{
                //    Console.WriteLine($"{payment.Name}{payment.Amount}{payment.GetType().Name}");
                //}

                var payments = context.Payments.ToList();
                foreach (var payment in context.Payments.OfType<CreditcardPayment>())
                {
                    Console.WriteLine($"{payment.Name}{payment.Amount}{payment.GetType().Name}");
                }
           
            }
        }
    }
}
