using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFStudy.Web.Core
{
    public interface IBlogService
    {
      void  UpdateUrl(Guid BlogId);
    }
}
