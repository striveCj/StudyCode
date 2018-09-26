using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFStudy.Model.T5
{
    public class AnotherBlogContext:DbContext
    {
        public AnotherBlogContext() : base("name=DBConnectionString")
        {

        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
