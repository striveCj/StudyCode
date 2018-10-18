using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFStudy.Model
{
    public class Student:BaseEntity
    {
        public string Name { get; set; }
        public byte Age { get; set; }

        /// <summary>
        /// 行版本
        /// </summary>
        public byte[] RowVersion { get; set; }

        public virtual StudentContact Contact { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
