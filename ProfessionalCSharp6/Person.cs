using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp6
{
   public class Person:IComparable<Person>
    {
        public DateTime Birthday { get; }
        public string FirstName { get; }

        public string LastName { get; }
        public Person(string firstName,string lastName, DateTime birthDay)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthDay;
        }

        public override string ToString() => $"{FirstName}{LastName}";

        public int CompareTo(Person other)
        {
            if (other == null) return 1;
            int result = string.Compare(this.LastName, other.LastName);
            if (result==0)
            {
                result = string.Compare(this.FirstName, other.FirstName);
            }
            return result;


        }
    }

    public class PersonCollection
    {
        private Person[] _people;
        public PersonCollection(params Person[] people) => _people = people.ToArray();

        public Person this[int index]
        {
            get => _people[index];
            set => _people[index] = value;
        }

        public  IEnumerable<Person> this[DateTime birthDay]
        {
            get => _people.Where(p => p.Birthday == birthDay);
        }
    }
}
