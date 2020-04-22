using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp13
{
    public class Person
    {
        public Person(string firstName,string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{FirstName}{LastName}";
        }

        public void Deconstruct(out string firstName,out string lastName)
        {
            firstName = FirstName;
            lastName = LastName;
        }
    }
}
