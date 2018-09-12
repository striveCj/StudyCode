using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFStudy.Model.Map
{
    public class CustomerMap:EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            ToTable("Customers");
            HasKey(t => t.Id);
            Property(t => t.Name).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired();
            Property(t => t.Email).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired();
            Property(t => t.CreatedTime);
            Property(t => t.ModifiedTime);
            //TODO:私有化属性映射
            //Property(Customer.PrivatePropertyExtension.test_private);
        }
    }
}
