using System;
using System.Collections.Generic;
using System.Text;

namespace ProfessionalCSharp12
{
    public class Formulal
    {
        private static List<Team> s_teams;
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
        public static List<Team> GetContructorChampions()
        {
            if (s_teams==null)
            {
                s_teams = new List<Team>()
                {
                    new Team("Matra",1966)
                };
            }
            return s_teams;
        }

        static void LinqQuery()
        {
            var query = from r in Formulal.GetChampions()
                        where r.Country == "Brazil"
                        orderby r.Wins descending
                        select r;
            foreach (var r in query)
            {
                Console.WriteLine($"{r:A}");
            }
        }
    }

   
}
