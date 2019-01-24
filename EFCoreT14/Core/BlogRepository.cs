using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreT14.Model;

namespace EFCoreT14.Core
{
    public class BlogRepository:IBlogRepository
    {
        private EFCoreDbContext _context;

        public BlogRepository(EFCoreDbContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<Blog>> GetBlogs()
        {
            var blogs = _context.Set<Blog>();
            return await Task.FromResult(blogs);
        }
    }
}
