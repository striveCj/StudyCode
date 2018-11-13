using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreStart.Model
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Introduce { get; set; }

        public DateTime CreatedTime { get; set; }

        public Student Student { get; set; }
    }
}
