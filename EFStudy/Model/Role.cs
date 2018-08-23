using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFStudy.Model
{
    public class Role:BaseEntity
    {
        public string RoleName { get; set; }
        public virtual List<UserRole> UserRoleList { get; set; }
    }
}
