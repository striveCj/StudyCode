using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDI.Core.Data;

namespace EFDI.Data.Mapping
{
    public class UserProfileMap:EntityTypeConfiguration<UserProfile>
    {
        public UserProfileMap()
        {
            ToTable("UserProfiles");

            HasKey(t => t.ID);

            Property(t => t.FirstName).IsRequired().HasMaxLength(100);
            Property(t => t.LastName).HasMaxLength(100);
            Property(t => t.Address);
            Property(t => t.CreatedTime).IsRequired();
            Property(t => t.ModifiedTime).IsRequired();
            Property(t => t.ID);

            HasRequired(t => t.User).WithRequiredDependent(u => u.UserProfile);
        }
    }
}
