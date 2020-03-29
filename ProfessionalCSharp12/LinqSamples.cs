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

        static void ConverWithCast()
        {
            var list = new System.Conllections.ArrayList(Formulal.GetChampions() as System.Collections.ICollection);

            var query = from r in list.Cast<Racer>()
                        where r.Country == "USA"
                        orderby r.Wins descending
                        select r;
            foreach (var item in query)
            {
                Console.WriteLine($"{item:A}");
            }
        }

        static void GenerateRange()
        {
            var values = Enumerable.Range(1, 20);
            foreach (var item in values)
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine();
        }

        static IEnumerable<int> SampleData()
        {
            const int arraySize = 50000000;
            var r = new Random();
            return Enumerable.Range(0, arraySize).Select(x => r.Next(140)).ToList();
        }

        static void LinqQuery(IEnumerable<int> data)
        {
            var res = (from x in data.AsParallel() where Math.Log(x) < 4 select x).Average();
        }

        static void UseAPartitioner(IList<int> data)
        {
            var result = (from x in Partitioner.Create(data, true).AsParallel() where Math.Log(x) < 4 select x).Average();
        }

        static void UseCancellation(IEnumerable<int> data)
        {
            var cts = new CancellatitonTokenSource();
            Task.Run(() =>
            {
                try
                {
                    var res = (from x in data.AsParallel().WithCancellation(cts.Token) where Math.Log(x) < 4 select x).Average();
                    Console.WriteLine(res);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            });
            Console.WriteLine("query started");
            Console.WriteLine("cancel?");
            string input = Console.ReadLine();
            if (input.ToLower().Equals("y"))
            {
                cts.Cancel();
            }
           
        }

    }
}
