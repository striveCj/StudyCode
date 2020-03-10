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

        public static List<Championship> s_championships;
        public static IEnumerable<Championship> GetChampionships()
        {
            if (s_championships==null)
            {
                s_championships = new List<Championship>
                {
                    new Championship(1950,"n","j","l")
                };
            }
            return s_championships;
        }
    }
}
