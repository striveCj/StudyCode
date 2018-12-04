using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreStart.Core;

namespace EFCoreStart.Model
{
    public class Blog:ISoftDeleteBaseEntity
    {
        public Blog() { }

        public Blog(string url)
        {
            _url = url;
            _status = "using";
        }

        private string _url;
        public string Url => _url;

        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime ModifiedTime { get; set; }

        private string _status = string.Empty;

        public override string ToString() => $"{Name},{Url},blog status:{_status}";
        public bool IsDeleted { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
