using System;
using System.Threading.Tasks;

namespace ProfessionalCSharp211
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static void ParallelFor()
        {
            ParallelLoopResult result = Parallel.For(0, 10, i =>
              {
                  Console.WriteLine($"S{i}");
                  Task.Delay(10).Wait();
                  Console.WriteLine($"E{i}");
              });

            Console.WriteLine($"Is completed{result.IsCompleted}");
        }

        public static void ParallelForWithAsync()
        {
            ParallelLoopResult result = Parallel.For(0, 10, async i =>
            {
                Console.WriteLine($"S{i}");
                await Task.Delay(10);
                Console.WriteLine($"E{i}");
            });
            Console.WriteLine(result.IsCompleted);
        }
    }
}
