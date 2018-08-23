using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
namespace EFStudy.Model.Map
{
    public class RoleMap:EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            ToTable("Role");
            HasKey(t => t.Id);
            Property(t => t.Id).HasColumnName("RoleId");
            Property(t => t.RoleName).HasMaxLength(30);
            HasMany(t => t.UserRoleList).WithOptional(t => t.Role);
        }
    }
}
