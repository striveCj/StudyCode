using System;
using System.Collections.Generic;
using System.Text;

namespace ProfessionalCSharp12
{
   public class Team
    {
        public Team(string name,params int[] years)
        {
            Name = name;
            Years = Years != null ? new List<int>(years) : new List<int>();

        }
        public string Name { get; }
        public IEnumerable<int> Years { get; }
    }
}
