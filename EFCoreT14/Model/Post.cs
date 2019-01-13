using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace EFCoreT14.Model
{
    public class Post: BaseEntity
    {
        public virtual string Title { get; set; }
        public virtual string Content { get; set; }
        public virtual int BlogId { get; set; }

        public  virtual Blog Blog { get; set; }
    }
}
