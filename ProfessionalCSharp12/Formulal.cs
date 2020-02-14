using System;
using System.Collections.Generic;
using System.Text;

namespace ProfessionalCSharp12
{
    public class Formulal
    {
        private static List<Racer> s_racers;
        public static IList<Racer> GetChampions() => s_racers;
    }
}
