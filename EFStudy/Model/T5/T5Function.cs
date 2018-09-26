using System;
using System.Collections.Generic;
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
    }
}
