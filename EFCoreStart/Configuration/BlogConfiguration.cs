using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreStart.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreStart.Configuration
{
    public class BlogConfiguration:IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.ToTable("Blogs");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.CreatedTime).HasColumnType("DATETIME").HasDefaultValueSql("getdate()");
            builder.Property(p=>p.ModifiedTime).HasColumnType("DATETIME").HasDefaultValueSql("getdate()");
            builder.Property(p => p.Url).HasColumnType("VARCHAR(100)").HasField("_url");
            builder.Property(p => p.Name).IsRequired();
            builder.Property<string>("TestBackingField").HasField("_status");
            builder.HasMany(m => m.Posts).WithOne(o => o.Blog).HasForeignKey(k => k.BlogId).IsRequired(false);

        }
    }
}
