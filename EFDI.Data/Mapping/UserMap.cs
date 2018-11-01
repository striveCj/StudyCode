using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDI.Core.Data;


namespace EFDI.Data.Mapping
{
    public class UserMap:EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("Users");
            HasKey(t => t.ID);
            Property(t => t.UserName).IsRequired();
            Property(t => t.Email).IsRequired();
            Property(t => t.PassWord).IsRequired();
            Property(t => t.CreatedTime).IsRequired();
            Property(t => t.ModifiedTime).IsRequired();
            Property(t => t.IP);

        }
    }
}
