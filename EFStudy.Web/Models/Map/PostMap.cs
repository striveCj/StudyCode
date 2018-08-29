using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace EFStudy.Web.Models.Map
{
    public class PostMap:EntityTypeConfiguration<Post>
    {
        public PostMap()
        {
            ToTable("Posts");
            HasKey(k => k.Id);
            Property(p => p.Title).IsRequired().HasColumnType("VARCHAR").HasMaxLength(50);
            Property(P => P.Content);
        }
    }
}