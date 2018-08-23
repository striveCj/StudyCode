using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace EFStudy.Model.Map
{
    public class UserRoleMap: EntityTypeConfiguration<UserRole>
    {
        public UserRoleMap()
        {
            ToTable("UserRole");
            HasKey(t => t.Id);
            Property(t => t.Id).HasColumnName("UserRoleId");
            //HasRequired(t => t.User).WithMany(t => t.UserRoleList).HasForeignKey(cc => cc.UserId);
            //HasRequired(t => t.Role).WithMany(t => t.UserRoleList).HasForeignKey(cc => cc.RoleId);
        }
    }
}
