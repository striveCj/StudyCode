using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreStart.Model
{
    public class Student
    {
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public int Age { get; set; }
        public Int64 Int64 { get; set; }
        public float Float { get; set; }
        public double Double { get; set; }
        public decimal Decimal { get; set; }
        public  byte Status { get; set; }
        public string Name { get; set; }
        public string Char { get; set; }
        public DateTime CreateTime { get; set; }

        public readonly  List<Course> _courses=new List<Course>();
        public IEnumerable<Course> Courses { get; set; }

        public void AddCourse(Course course)
        {
            _courses.Add(course);
        }
    }
}
