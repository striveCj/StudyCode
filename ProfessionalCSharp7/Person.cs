using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp7
{
    public class Person
    {
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public Person() { }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string ToString() => $"{FirstName}{LastName}";
    }
}
