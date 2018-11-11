using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreStart.Model
{
    public class Blog
    {
        private Blog() { }

        public Blog(string url)
        {
            _url = url;
        }

        private string _url;
        public string Url => _url;

        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime ModifiedTime { get; set; }
    }
}
