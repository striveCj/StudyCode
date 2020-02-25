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
    }
}
