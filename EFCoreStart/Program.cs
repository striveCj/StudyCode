using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

                //var payments = context.Payments.ToList();
                //foreach (var payment in context.Payments.OfType<CreditcardPayment>())
                //{
                //    Console.WriteLine($"{payment.Name}{payment.Amount}{payment.GetType().Name}");
                //}
                //TODO: 当使用主键查询时使用Find方法性能会更好
                //var blog = context.Blogs.Find(1);
                //var blogs = context.Blogs.FirstOrDefault(d => d.Id == 1);
                //TODO:复合主键
                //var productCategory = context.Blogs.Find(1, 1);
                //TODO:利用Find或者FindAsync方法不能进行饥饿加载(Include),但是我们任然能够通过上下文的Entry方法中的Navigations属性加载导航属性实现饥饿加载
            
                
                //var student = context.Students.Find(Convert.ToInt32(3));
                //foreach (var navigation in context.Entry(student).Navigations)
                //{
                //    navigation.Load();
                //}

                //TODO:在继承映射TPH模式中，可以用OfType方法转换为具体类，所以此方法与查询运算符等值条件等价
                //var patments = context.Payments.OfType<CashPayment>();
                //Console.WriteLine(patments.FirstOrDefault()?.Name);
                //TODO:也可以用Cast进行转换与OfType的区别是，Cast将翻译成In子句
                //var payments = context.Payments.Cast<CashPayment>();
                //Console.WriteLine(payments.FirstOrDefault()?.Name);
                //TODO:EF Code不支持使用OfType和Cast转换原始类型
                //var paymentss = context.Payments.Select(d => d.PaymentId).OfType<string>();
                //Console.WriteLine(paymentss);
                //TODO:C# 中可以使用if和as来进行类型转换。如果一个对象是某个类型或是其父类型，就返回true否则返回false，Is永远不会抛出异常，As会
                //TODO:Is进行类型转换等同于Cast在sql中都会翻译成in子句
                //var payments = context.Payments.Where(d => d is CashPayment);
                //Console.WriteLine(payments.FirstOrDefault()?.Name);
                //TODO:调用Select会翻译成Select子句，投影不仅支持实体，同时支持匿名函数
                //var paymentss = context.Payments.Select(d => d.Name + " ");
                //Console.WriteLine(paymentss.FirstOrDefault()); 
                //TODO:DefaultIfEmpty常用于左连接，若查询序列为空，则返回实例类型默认值
                //var blogs = context.Blogs.Where(d => d.Id == 0).DefaultIfEmpty();
                //Console.WriteLine(blogs.FirstOrDefault()==default(Blog));
                //TODO:DefaultIfEntity还有重载可接受一个指定的默认值，在EFCore中将不会翻译为SQL，而是在本地检查结果，如果没有行就会产生指定的默认值
                //var defaultBlog = new Blog(){Name = nameof(Blog)};
                //var blogss = context.Blogs.Where(d => d.Id == 0).DefaultIfEmpty(defaultBlog);
                //Console.WriteLine(blogss.FirstOrDefault()?.Name);
                //TODO:EFCore还不支持分组，它只优化了GroupBy,将GroupBy中的OrderBy子句进行了翻译，将SQL执行结果读取到本地，逐一进行分组
                var blogs = context.Blogs.GroupBy(d => d.Id);
                Console.WriteLine(blogs.FirstOrDefault()?.FirstOrDefault()?.Name);
                //TODO:会翻译为inner join
                var outerBlogs = context.Blogs;
                var innerPosts = context.Set<Post>();

                var outerBlogQuery = outerBlogs.Join(innerPosts, b => b.Id, p => p.BlogId,
                    ((blog, post) => new {Id = blog.Id, Name = blog.Name}));
                Console.WriteLine(outerBlogQuery.FirstOrDefault()?.Name);
                //TODO:使用Select和SelectMany可以实现CROSS JOIN 交叉查询(求两个表的笛卡尔积)
                var outerBlogQuert2 = outerBlogs.Select(b => new
                {
                    Id = b.Id,
                    Name = b.Name,
                    Posts = innerPosts.Where(p => p.BlogId == b.Id)
                }).SelectMany(collectionSelector: b => b.Posts,
                    resultSelector: (b, p) => new {Id = b.Id, Name = b.Name});
                Console.WriteLine(outerBlogQuert2.FirstOrDefault()?.Name);
                //TODO:GroupJoin最终被翻译成LeftJoin
                var outerBlogQusert3 = outerBlogs.GroupJoin(inner: innerPosts, outerKeySelector: b => b.Id, innerKeySelector: p => p.BlogId, resultSelector: (b, p) => new { Id = b.Id, Name = b.Name, Posts = b.Posts });
                Console.WriteLine(outerBlogQusert3.FirstOrDefault()?.Name);
                //TODO:EFCore中不支持连接翻译SQL，支持本地和合并。下面代码会抛出异常。
                var first = context.Blogs.Where(item=>item.Id>=1);
                var second = context.Blogs.Where(item => item.Id <= 2);
                var blogs2 = first.Concat(second).Select(d => new { Id = d.Id, Name = d.Name });
                Console.WriteLine(blogs2.FirstOrDefault()?.Name);
                //TODO:下面为本地合并
                var first1 = context.Blogs.Where(item => item.Id >= 1).Select(d=>d.Name);
                var second1 = context.Blogs.Where(item => item.Id <= 2).Select(d=>d.Name);
                var name = first.Concat(second);
                Console.WriteLine(name.FirstOrDefault());
                //TODO:Skip和Take会转换成SQL中的OFFSET和LIMIT分页关键字
                var blogs3 = context.Blogs.Skip(1).Take(10);
                Console.WriteLine(blogs3.DefaultIfEmpty());
                //TODO:EFCore中会将Contains转换成SQL中的In谓词       
                var blogs4 = context.Blogs.Select(d => d.Id).Contains(1);
                Console.WriteLine(blogs4);
                //TODO:EFCore中会将字符串的Contains转换成CHARINDEX
                var blogs5 = context.Blogs.Select(d => d.Name.Contains("J"));
                Console.WriteLine(blogs5.FirstOrDefault());
                //TODO:EFCorez中会将数组集合的Contains翻译成In子句
                var nameArray = new string[] { "a", "b", "c" };
                var blogs6 = context.Blogs.Where(item => nameArray.Contains(item.Name));
                Console.WriteLine(blogs6.FirstOrDefault()?.Name);
                //TODO:EFCore中会将Any翻译EXISTS将All翻译成NOT EXISTS
                var blogs7 = context.Blogs.Any(i => i.Id == 1);
                var blogs8 = context.Blogs.All(item => item.Id == 1);
                Console.WriteLine(blogs7);
                Console.WriteLine(blogs8);
                //TODO:在EFCore中使用Include可执饥饿加载，如果有多个导航属性，可以用Include，如果导航属性需要饥饿加载使用ThenInclude
                var blogs9 = context.Blogs.Include(item => item.Posts);
                //TODO:如果在Include后更改了查询结果，那么Include将会被忽略
                var blogs10 = context.Blogs.Include(item => item.Posts).Select(b => new { ID = b.Id });
                //TODO:EFCore1.1中添加的显示加载
                var blogs11 = context.Blogs.FirstOrDefault();
                context.Entry(blogs11).Collection(b=>b.Posts).Load();
                //TODO:调用原生SQL
                var blogs12 = context.Blogs.FromSql<Blog>("select * from blogs").ToList();
                //TODO:也可以使用字符串插值
                var blogs13 = context.Blogs.FromSql($"select * from blogs where Id={1}");
                //TODO:使用 FormattableString可以防止SQL注入 。调用原,生查询后同样可以用Include关联
                FormattableString formattable = $"select * from blogs where Id={1}";
                var blogs14 = context.Blogs.FromSql(formattable).Include(b => b.Posts).ToList();
                //TODO:原生执行增删改操作
                var commandSql = "Insert into blog(name,url) values(@name,@url)";
                var sqlParameter = new SqlParameter[] {
                    new SqlParameter("@name",System.Data.SqlDbType.NVarChar),
                    new SqlParameter("@url",System.Data.SqlDbType.NVarChar)
                };
                sqlParameter[0].Value = "张三";
                sqlParameter[1].Value = "www.chenjieloveyou.com";
                context.Database.ExecuteSqlCommand(commandSql, sqlParameter);
                //批处理声明
                var blogs15 = new Blog
                {
                    CreatedTime=DateTime.Now,
                    ModifiedTime=DateTime.Now,
                    Name="陈杰"

                };
                context.ChangeTracker.TrackGraph(blogs15, node =>
                {
                    var entry = node.Entry;
                    if ((int)entry.Property("Id").CurrentValue<0)
                    {
                        entry.State = EntityState.Added;
                        entry.Property("Id").IsTemporary = true;
                    }
                    else
                    {
                        entry.State = EntityState.Modified;
                    }
                });

                var excetingBlogs = context.Blogs.Find(1);
                if (excetingBlogs==null)
                {
                    context.Add(blogs);
                }
                else
                {
                    context.Entry(excetingBlogs).CurrentValues.SetValues(blogs);
                }
                context.SaveChanges();
                //TODO:无实体更新
                var blogs17 = context.Blogs.Include(item => item.Posts).FirstOrDefault(item => item.Id == 2);
                blogs17.Name = "aaa";
                blogs17.Posts.All(p =>
                {
                    p.Name = "bbb";
                    return true;
                });
                context.Update(blogs17);
                var result = context.SaveChanges();

                //TODO:无实体更新无主键
                var blogs18 = context.Blogs.Include(item => item.Posts).FirstOrDefault(item => item.Id == 2);
              
                if (blogs18==null)
                {
                    context.Blogs.Add(blogs17);
                }
                else
                {
                    context.Entry(blogs18).CurrentValues.SetValues(blogs17);
                    foreach (var post in blogs17.Posts)
                    {
                        var nowPost= blogs18.Posts.FirstOrDefault(item => item.Id == post.Id);
                        if (nowPost==null)
                        {
                            blogs18.Posts.Add(post);
                        }
                        else
                        {
                            context.Entry(nowPost).CurrentValues.SetValues(post);
                        }
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
