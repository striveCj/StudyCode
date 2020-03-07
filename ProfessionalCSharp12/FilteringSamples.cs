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

        static void GroupingAndNestedObjects()
        {
            var countries = from r in Formulal.GetChampions()
                            group r by r.Country into g
                            let count = g.Count()
                            orderby count descending, g.Key
                            where count >= 2
                            select new
                            {
                                Country = g.Key,
                                Count = coung,
                                Racers = from r1 in g
                                         orderby r1.LastName
                                         select r1.FirstName + " " + r1.LastName

                            };
            foreach (var item in countries)
            {
                Console.WriteLine($"{item.Country,-10}{item.Count}");
                foreach (var name in item.Racers)
                {
                    Console.WriteLine(name);
                }
                Console.WriteLine();
            }
        }

        static void GroupingAndNestedObjectsWithMethods()
        {
            var countries = Formulal.GetChampions().GroupBy(r => r.Country)
                .Select(g => new {
                    Group = g,
                    Key = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(g => g.Count)
                .ThenBy(g => g.Key)
                .Where(g => g.Count >= 2)
                .Select(g => new
                {
                    Country = g.Key,
                    Count = g.Count,
                    Racers = g.Group.OrderBy(r => r.LastName),
                    .Select(r => r.FirstName + " " + r.LastName)
                });

        }
        static void InnerJoin()
        {
            var racers = from r in Formulal.GetChampions()
                         from y in r.Years
                         select new
                         {
                             Year = y,
                             Name = r.FirstName + " " + r.LastName
                         };
            var teams = from t in Formulal.GetContructorChampions()
                        from y in t.Years
                        select new
                        {
                            Year = y,
                            Name = t.Name
                        };
            var racersAndTeams=(from r in racers ioin
                t in teams on r.Year equals t.Year
                select new
                {
                    r.Year,
                    Champion=racers.Name,
                    Constructpr=t.Name
                }).Take(10);
            Console.WriteLine("t");
            foreach (var item in racersAndTeams)
            {
                Console.WriteLine(item.Year);
            }
        }
        static void InnerJoinWithMethods()
        {
            var racers = Formulal.GetChampions()
                .SelectMany(r => r.Years, (r1, year) => new
                {
                    Year = year,
                    Name = $"{r1.FirstName}{r1.LastName}"
                });
            var teams = Formulal.GetConstrutorChampions().SelectMany(t => t.Years, (t, year) => new
            {
                Year = year,
                Name = t.name
            });

            var racersAndTeams = racers.Join(teams, r => r.Year, t => t.Year, (r, t) => new
            {
                Year = r.Year,
                Champion = r.Name,
                Constructor = t.Name
            }).OrderBy(item => item.Year).Take(10);
        }
        static void LeftOuterJoin()
        {
            var racersAndTeams = (from r in racers
                                  join t in teams on r.Year equals t.Year into rt
                                  from t in rt.DefaultIfRmpty()
                                  orderby r.Year
                                  select new
                                  {
                                      Year = r.Year,
                                      Champion = r.Name,
                                      Constructor = t == null ? "no" : t.Name
                                  }
                                  ).Take(10);
        }
        
        static void LeftOuterJoinWithMethods()
        {
            var racersAndTeams = racers.GroupJoin(teams, r => r.Year, t => t.Year, (r, ts) => {
                Year = r.Year,
                Champion = r.Name,
                Constructors = ts
                     }).SelectMany(rt => rt.Constructors.DefaultIfEmpty(), (r, t) => new {
                Year = r.Year,
                Champion = r.Champion,
                Constructor = t?.Name ?? "no"
            });
        }

    }
}
