using System;
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
                    Console.WriteLine(item);；
                }
            }
        }
    }
}
