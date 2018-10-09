using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using EFStudy.Model.T5;

namespace EFStudy.Model.Map.T5
{
    public class CategoryMap:EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            ToTable("Categoryies");
            HasKey(k => k.CategoryId);
            Property(p => p.CategoryName).IsUnicode().HasMaxLength(50);
            HasMany(p => p.Products).WithRequired(c => c.Category).HasForeignKey(k => k.CategoryId);
        }
    }
}
