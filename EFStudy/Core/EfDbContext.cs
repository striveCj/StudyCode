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
        public EfDbContext()
        {
           
        }
        public DbSet<Blog> Blogs { get; set; }
    }
}
