using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreT14.Model;

namespace EFCoreT14.Core
{
    public interface IBlogRepository
    {
        Task<IQueryable<Blog>> GetBlogs();
    }
}
