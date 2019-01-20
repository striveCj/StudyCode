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
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.ToTable("Blogs");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Url);
            builder.Property(p => p.Name);
            builder.Property(p => p.CreateTime).HasColumnType("DATETIME").HasDefaultValueSql("GETDATE()");

            builder.HasQueryFilter(p => !p.IsDeleted);

            builder.HasMany(p => p.Posts).WithOne(o => o.Blog).HasForeignKey(k => k.BlogId);
        }
    }
}
