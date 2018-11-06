using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreStart.Model
{
    public class Student
    {
        public int Id { get; set; }

        public int Age { get; set; }

        public  byte Status { get; set; }
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
