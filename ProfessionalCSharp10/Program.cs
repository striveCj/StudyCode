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
            var intList2=new List<int>();
            intList2.Add(1);
            intList2.Add(2);
            var stringList=new List<string>();
            stringList.Add("one");
            stringList.Add("two");

            var  graham=new Racer(7,"Graham","Hill","UK",14);
            var emerson = new Racer(7, "Graham", "Hill", "UK", 14);
            var mario = new Racer(7, "Graham", "Hill", "UK", 14);
            var racers2 = new List<Racer>(20){ graham,emerson,mario};
            racers2.Add(new Racer(24,"a","b","c",25));
            racers2.Add(new Racer(21,"a","b","c",22));


        }
    }

}
