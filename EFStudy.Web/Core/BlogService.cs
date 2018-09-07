using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFStudy.Web.Core
{
    public class BlogService:IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;// ?? throw new ArgumentNullException("BlogRepository");
        }

        public void UpdateUrl(Guid BlogId)
        {
            using (var context=new EFDbContext())
            {
                var blog = _blogRepository.Get(context, BlogId);
                blog.Url = "http://www.baidu.com";
                context.SaveChanges();
            }
        }
    }
}