using System;
using System.Collections.Generic;

namespace EFCoreT14.Model
{
    public class Blog:BaseEntity
    {
     
        public string Name { get; set; }

        public  string Url { get; set; }

        public DateTime CreateTime { get; set; }
       
        public IEnumerable<Post> Posts { get; set; }
    }
}
