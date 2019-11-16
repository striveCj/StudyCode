using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp10
{
    class Program
    {
        static void Main(string[] args)
        {
            //var intList = new List<int>();
            var racers=new List<Racer>();
            List<int> intList=new List<int>(10);
            intList.Capacity = 20;
            intList.TrimExcess();
        }
    }

}
