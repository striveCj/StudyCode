﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProfessionalCSharp12
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
        public int CompareTo(Racer other)
        {
            throw new NotImplementedException();
        }
    }
}
