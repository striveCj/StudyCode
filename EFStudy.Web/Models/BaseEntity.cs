using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFStudy.Web.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifiedTime { get; set; }
    }
}