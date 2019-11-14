using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp10
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Racer : IComparable<Racer>, IFormattable
    {
        public int Id { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string Country { get; }

        public  int Wins { get; }

        public Racer(int id,string firstName,string lastName,string country) :this(id,firstName,lastName,country, wins: 0){ }

        public Racer(int id, string firstName, string lastName, string country,int wins)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Country = country;
            Wins = wins;
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(Racer other)
        {
            throw new NotImplementedException();
        }
    }

}
