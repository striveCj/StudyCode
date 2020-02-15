using System;
using System.Collections.Generic;
using System.Text;

namespace ProfessionalCSharp12
{
    public class Formulal
    {
        private static List<Racer> s_racers;
        public static IList<Racer> GetChampions() => s_racers?? InitializeRacers();

        private static List<Racer> InitializeRacers()
        {
            return new List<Racer>
        {
            new Racer("Nino","Farina","Italy",33,5,new int[]{1950},new string[] {"Alfa Rome" }),
             new Racer("Nino1","Farina1","Italy1",33,5,new int[]{1950},new string[] {"Alfa Rome1" }),
              new Racer("Nino2","Farina2","Italy2",33,5,new int[]{1950},new string[] {"Alfa Rome2" }),
        };
        }

    }
}
