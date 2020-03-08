using System;
using System.Collections.Generic;
using System.Text;

namespace ProfessionalCSharp12
{
    public class Championship
    {
        public int Year { get; }

        public string First { get; }

        public string Second { get; }
        public string Third { get; }

        public Championship(int year,string first,string second,string third)
        {
            Year = year;
            First = first;
            Second = second;
            Third = third;
        }
    }
}
