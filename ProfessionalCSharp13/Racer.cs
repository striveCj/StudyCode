using System;
using System.Collections.Generic;
using System.Text;

namespace ProfessionalCSharp13
{
    public class Racer : IComparable<Racer>, IFormattable
    {
        public Racer(string firstName, string lastName, string country, int starts, int wins) : this(firstName, lastName, country, starts, wins, null, null)
        {

        }
        public Racer(string firstName, string lastName, string country, int satarts, int wins, IEnumerable<int> years, IEnumerable<string> cars) {
            FirstName = firstName;
            LastName = lastName;
            Starts = satarts;
            Wins = wins;
            Country = country;
            Cars = cars;
            Years = years;

        }
        public string FirstName { get; }
        public string LastName { get; }
        public int Starts { get; }
        public int Wins { get; }

        public string Country { get; }
        public IEnumerable<string> Cars { get; }

        public IEnumerable<int> Years { get; }

        public override string ToString()
        {
            return 
                $"{LastName}{FirstName}";
        }
        public int CompareTo(Racer other) => LastName.CompareTo(other?.LastName);

        public string ToString(string format) => ToString(format, null);

        public string ToString(string format, IFormatProvider formatProvider)
        {
            switch (format)
            {
                case null:
                case "N":
                    return ToString();
                case "F":
                    return FirstName;
                    
                default:
                    throw new NotImplementedException();
            }
            
        }
    }
}
