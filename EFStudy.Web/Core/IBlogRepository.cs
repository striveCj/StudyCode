using EFStudy.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFStudy.Web.Core
{
    public interface IBlogRepository
    {
        Blog Get(EFDbContext context, Guid BlogId);
    }
}
