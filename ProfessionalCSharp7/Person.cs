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

    public class Person2 : IEquatable<Person2>
    {
        public int Id { get; }
        public  string FirstName { get; }

        public  string LastName { get; }

        public Person2(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
           return $"{Id},{FirstName}，{LastName}";
        }

        public override bool Equals(object obj)
        {
            if (obj==null)
            {
                return base.Equals(obj);
            }
            return Equals(obj as Person);
            
        }

        public override int GetHashCode() => Id.GetHashCode();

        public bool Equals(Person2 other)
        {
            if (other==null)
            {
                return base.Equals(other);
            }
            return Id == other.Id && FirstName == other.FirstName && LastName == other.LastName;
        }
    }



    
}
