using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp5
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new ArrayList();
            list.Add(44);
            int t1 = (int) list[0];
            foreach (var i2 in list)
            {
                Console.WriteLine(i2);
            }
            var list2 = new List<int>();
            list.Add(44);
            int t2 = list2[0];
            foreach (var i2 in list2)
            {
                Console.WriteLine(i2);
            }

        }
    }
}
