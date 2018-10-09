using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using EFStudy.Model.T5;

namespace EFStudy.Model.Map.T5
{
    public class ProductMap:EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable("Products");
            HasKey(k => k.ProductId);
            Property(p => p.ProductName).IsUnicode(false).HasMaxLength(50);
        }
    }
}
