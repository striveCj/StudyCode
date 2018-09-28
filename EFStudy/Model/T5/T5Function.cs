using EFStudy.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFStudy.Model.T5
{
    public static class T5Function
    {
        public  static void T5D1()
        {
            using (var context=new AnotherBlogContext())
            {
                var post = context.Posts.Single(p => p.Title == "My First Post");
                post.Title = "My Best Post";
                context.SaveChanges();
            }
        }

        public static void T5D2()
        {
            using (var context=new AnotherBlogContext())
            {
                context.Blogs.Load();
                var post = context.Posts.Single(p => p.Title == "My First Post");
                post.Title = "My Best Post";
                post.BlogId = 7;
                context.SaveChanges();
            }
        }

        public static void T5D3()
        {
            using (var context = new AnotherBlogContext())
            {
                context.Blogs.Load();
                var post = context.Posts.Single(p => p.Title == "My First Post");
                Console.WriteLine(context.Entry(post).State);
                //或者
                var entry = context.Entry<Post>(post);
                Console.WriteLine(entry.State);
            }
        }
        public static void T5D4()
        {
            using (var context = new AnotherBlogContext())
            {
                var post = context.Posts.First(p => p.BlogId == 1);
                post.BlogId = 2;
                var blog2 = context.Blogs.Find(2);
            }
        }

        public static void AddPosts(List<Post> Posts)
        {
            using (var context=new AnotherBlogContext())
            {
                try
                {
                    context.Configuration.AutoDetectChangesEnabled = false;
                    Posts.ForEach(p => context.Posts.Add(p));
                }
                finally
                {
                    context.Configuration.AutoDetectChangesEnabled = true;
                }
                context.SaveChanges();
            }
        }

        public static void AttachAndMovePosts(Blog efBlog,List<Post> Posts)
        {
            using (var context=new AnotherBlogContext())
            {
                try
                {
                    context.Configuration.AutoDetectChangesEnabled = false;
                    context.Blogs.Attach(efBlog);
                    Posts.ForEach(p =>
                    {
                        context.Posts.Attach(p);
                        if (p.Title.StartsWith("Entity Framework:"))
                        {
                            context.Entry(p).Property(p2 => p2.Title).CurrentValue = p.Title.Replace("Entity Framework:", "EF:");
                            context.Entry(p).Reference(p2 => p2.Blog).CurrentValue = efBlog;
                        }
                    });
                    context.SaveChanges();
                }
                finally
                {
                    context.Configuration.AutoDetectChangesEnabled = true;
                }
            }
        }
        /// <summary>
        /// 日志记录 toString 打印
        /// </summary>
        public static void T5D5()
        {
            using (var ctx=new EfDbContext())
            {
                var blog = ctx.Customer;
                var sql = blog.ToString();
                Console.WriteLine(sql);
            }
        }

        public static void T5D6()
        {
            using (var ctx = new EfDbContext())
            {
                ctx.Database.Log = Console.WriteLine;
                var cutsomer = ctx.Customer.FirstOrDefault(d => d.Id == 1);
            }
        }

        public static void T5D7()
        {
            using (var ctx = new EfDbContext())
            {
                ctx.Database.Log = msg => MyLogger.Log("EFLoggingDemo", msg);
                var cutsomer = ctx.Customer.FirstOrDefault(d => d.Id == 1);
            }
        }

    }
    public class MyLogger
    {
        public static void Log(string application,string message)
        {
            Console.WriteLine($"Application:{application},EF Message{message}");
        }

    }
}
