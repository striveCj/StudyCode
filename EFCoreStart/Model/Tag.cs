using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreStart.Model
{
  public  class Tag
    {
        public int TagId { get; set; }
        public string Text { get; set; }

        private ICollection<PostTag> PostTags { get; } = new List<PostTag>();
        [NotMapped]
        public IEnumerable<Post> Posts => PostTags.Select(e => e.Posts);

    }
}
