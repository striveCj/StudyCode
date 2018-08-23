using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFStudy.Model.Map
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("User");
            HasKey(t => t.Id);
            Property(t => t.Id).HasColumnName("UserId");
            Property(t => t.Name).HasMaxLength(30);
            HasMany(t => t.UserRoleList).WithRequired(t => t.User);
        }
    }
}
