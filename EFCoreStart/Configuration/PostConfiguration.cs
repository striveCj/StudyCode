using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreStart.Configuration
{
    public class PostConfiguration:IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();
            builder.Property(p => p.CreatedTime).HasColumnType("DATETIME").HasDefaultValueSql("GETDATE()");
            builder.Property(p => p.ModifiedTime).HasColumnType("DATETIME").HasDefaultValueSql("GETDATE()");

        }
    }
}
