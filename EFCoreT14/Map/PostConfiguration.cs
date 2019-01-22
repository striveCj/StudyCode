using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreT14.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreT14.Map
{
    public class PostConfiguration:IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");
            builder.Property(k => k.Id);
            builder.Property(p => p.Title);
            builder.Property(p => p.Content);

            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
