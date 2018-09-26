using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFStudy.Model.T5
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual IConvertible Posts { get; set; }
    }
}
