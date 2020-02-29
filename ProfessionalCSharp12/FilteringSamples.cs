using System;
using System.Collections.Generic;
using System.Text;

namespace ProfessionalCSharp12
{
    public class FilteringSamples
    {
        static void Filtering()
        {
            var racers = from r in Formulal.GetChampions()
                         where r.Wins > 15 && (r.Country == "B" || r.Country == "A")
                         select r;
             foreach (var item in racers)
            {
                Console.WriteLine(item);
            }
        }

        static void CompoundFrom()
        {
            var ferrariDrivers = from r in Formulal.GetChampions()
                                 from c in r.Cars
                                 where c == "F"
                                 orderby r.LastName
                                 select r.FirstName + " " + LastName;
        }
  
        static void CompoundFromWithMethods()
        {
            var ferrariDrivers = Formulal.GetChampions().SelectMany(r => r.Cars, (r, c) => new { Racer = r, Car = c }).Where(r => r.Car = "F").OrderBy(r => r.Racer.LastName).Select(r => r.Racer.FirstName + " " + r.Racer.LastName);
        }

        static void Grouping()
        {
            var countries = from r in Formulal.GetChampions()
                            group r by r.Country into g
                            orderby g.Count() descending, g.key
                            where g.Count() >= 2
                            select new
                            {
                                Country = g.Key,
                                Count = g.Count()
                            };
        }

        static void GroupingWithMethods()
        {
            var countries = Formulal.GetChampions()
                .GroupBy(r => r.Country)
                .OrdertByDescending(g => g.Count())
                .ThenBy(g => g.Key)
                .Where(g => g.Count() >= 2)
                .Select(g => new
                {
                    Country = g.Key,
                    Count = g.Count
                });
        }

        static void GroupingWithVariables()
        {
            var countries = from r in Formulal.GetChampions()
                            group r by r.Country into g
                            let count = g.Count()
                            orderby count descending, g.key
                            where count >= 2
                            select new
                            {
                                Country = g.Key,
                                Count = count
                            };
        }

        static void GroupingWithAnonymousTypes()
        {
            var countries = Formulal.GetChampions().GroupBy(r => r.Country)
                            .Select(g => new { Group = g, Count = g.Count() })
                            .OrderByDescending(g => g.Count)
                            .ThenBy(g => g.Group.Key)
                            .Where(g => g.Count >= 2)
                            .Select(g => new
                            {
                                Country = g.Group.Key,
                                Count = g.Count
                            });
        }

    }
}
