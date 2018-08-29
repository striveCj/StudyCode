using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFStudy.Web.Models
{
    public class Post:BaseEntity
    {
        [Required]
        public string Title { get; set; }
        [Required] 

        public string Content { get; set; }

        public int BlogId { get; set; }

        public virtual Blog Blog { get; set; }
    }
}