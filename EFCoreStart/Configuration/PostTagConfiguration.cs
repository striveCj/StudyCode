using EFCoreStart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreStart.Configuration
{
    public class PostTagConfiguration : IEntityTypeConfiguration<PostTag>
    {
        public void Configure(EntityTypeBuilder<PostTag> builder)
        {
            builder.ToTable("PostTags");
            builder.HasKey(k =>new {k.PostId,k.TagId });
            builder.HasOne(pt => pt.Post).WithMany("PostTags");
            builder.HasOne(pt => pt.Tag).WithMany("PostTags");
        }
    }
}
