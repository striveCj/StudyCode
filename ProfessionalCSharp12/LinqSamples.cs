﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProfessionalCSharp12
{
    public class LinqSamples
    {
        static void Partitioning()
        {
            int pageSize = 5;
            int numberPages = (int)Math.Ceiling(Formulal.GetChampions().Count() / (double)pageSize);
            for (int i = 0; i < numberPages; i++)
            {
                Console.WriteLine(i);

                var racers = (from r in Formulal.GetChampions() orderby r.LastName, r.FirstName select r.FirstName + " " + r.LastName).Skip(pageSize * pageSize).Take(pageSize);
                foreach (var item in racers)
                {
                    Console.WriteLine(item);
                }
            }
        }

        static void AggregateCount()
        {
            var query = from r in Formulal.GetChampions()
                        let numberYears = r.Years.Count()
                        where numberYears >= 3
                        orderby numberYears descending, r.LastName
                        select new
                        {
                            Name = r.FirstName + " " + r.LastName,
                            TimeChampion = numberYears
                        };
            foreach (var item in query)
            {
                Console.WriteLine($"{item.Name}{item.TimeChampion}");
            }
        }

        static void ToList()
        {
            List<Racer> racers = (from r in Formulal.GetChampions()
                                  where r.Statrts > 200
                                  orderby r.Starts descending
                                  select r).ToList();
            foreach (var item in racers)
            {
                Console.WriteLine(item);
            }
        }

        static void ToLookup()
        {
            var racers = (from r in Formulal.GetChampions() from c in r.Cars select new { Car = c, Racer = r }).ToLookup(cr => cr.Car, cr => cr.Racer);
            if (racers.Contains("Williams"))
            {
                foreach (var item in racers["Williams"])
                {
                    Console.WriteLine(item);
                }
            }
            
        }
    }
}
