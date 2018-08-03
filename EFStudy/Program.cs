using EFStudy.Core;
using System;
using System.Collections.Generic;
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
                efDbContext.Blogs.Add(new Model.Blog()
                {
                    Name = "陈杰",
                    Url = "http://www.cnblogs.com/chen-jie"
                });
                efDbContext.SaveChanges(); 
            }
        }
    }
}
