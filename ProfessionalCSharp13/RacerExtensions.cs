using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp13
{
    public static class RacerExtensions
    {
        public static void Deconstruct(this Racer r,out string firstName,out string lastName,out int starts,out int wins)
        {
            firstName = r.FirstName;
            lastName = r.LastName;
            starts = r.Starts;
            wins = r.Wins;
        }

        static void DeconstructWithExtensionsMethods()
        {
            var racer = Formulal.GetChampions().Where(r=>r.LastName=="Lauda").First();
            (string first, string last, _, _) = racer;
            Console.WriteLine($"{first}{last}");
        }


    }
}
