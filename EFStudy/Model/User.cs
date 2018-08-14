using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFStudy.Model
{
     public class User:BaseEntity
    {
        public User()
        {
            Address = new Address();
        }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string IDNumber { get; set; }

        public Address Address { get; set; }
    }
}
