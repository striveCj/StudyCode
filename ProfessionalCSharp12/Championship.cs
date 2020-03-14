﻿using System;
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

        static void GroupJoin()
        {
            var racers = from cs in Formulal.GetContructorChampions()
                         from r in new List<(int Year, int Position, string FirstName, string LastName)>()
                        {
                            (cs.Year,1,cs.First.LastName())
                        }
                         select r;
        }
    
 
       
    }
}
public static class StringExtensions
{
    public static string FirstName(this string name) => name.Substring(0, name.LastIndexOf(' '));

    public static string LastName(this string name) => name.Substring(0, name.LastIndexOf(' ')+1);

}

public void GroupJoin()
{
    var q = (from r in Formulal.GetChampions()
             join r2 in racers on (r.FirstName, r.LastName)
             equals (r2.FirstName, r2.LastName)
             into yearResults
             select (r.FirstName, r.LastName, r.Wins, r.Starts, Results: yearResults));
    foreach (var r in q)
    {
        Console.WriteLine(r.FirstName);
        foreach (var item in r.Results)
        {
            Console.WriteLine(item.Year);
        }
    }
}