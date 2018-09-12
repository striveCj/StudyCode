using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFStudy.Model
{
    public class BaseEntity
    {
        public virtual int Id { get; set; }

        public virtual DateTime CreatedTime { get; set; }

        public virtual DateTime ModifiedTime { get; set; }
    }
}
