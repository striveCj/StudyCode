using EFStudy.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFStudy.Web.Core
{
    public class BlogRepository:IBlogRepository
    {
        public Blog Get(EFDbContext context,Guid BlogId)
        {
            return context.Set<Blog>().Find(BlogId);
        }

    }
}