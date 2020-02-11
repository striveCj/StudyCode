using System;
using System.Collections.Generic;
using System.Text;

namespace ProfessionalCSharp12
{
    public class Racer : IComparable<Racer>, IFormattable
    {
        public Racer(string firstName, string lastName, string country, int starts, int wins) : this(firstName, lastName, country, starts, wins, null, null)
        {

        }
        public Racer(string firstName,string lastName,string country, int satarts, int wins, IEnumerable<int> years, IEnumerable<string> cars) {

        }

        public int CompareTo(Racer other)
        {
            throw new NotImplementedException();；
        }
    }
}
