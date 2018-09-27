using System;
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
    }
}
