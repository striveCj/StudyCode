using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreStart.Core;

namespace EFCoreStart.Model
{
    public class Post:ISoftDeleteBaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime ModifiedTime { get; set; }
        public Blog Blog { get; set; }
        public int BlogId { get; set; }
        public bool IsDeleted { get; set; }
        private ICollection<PostTag> PostTags { get; } = new List<PostTag>();
        [NotMapped]
        public IEnumerable<Tag> Tags => PostTags.Select(e => e.Tags);
    }
}
