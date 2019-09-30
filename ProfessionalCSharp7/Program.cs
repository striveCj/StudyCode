using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp7
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names =
            {
                "Christina Aguilera",
                "Shakira",
                "Beyonce",
                "Lady Gaga"
            };
            Array.Sort(names);
            foreach (var name in names)         {
                Console.WriteLine(names);
            }
        }
    }
}
