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
  
    }
}
