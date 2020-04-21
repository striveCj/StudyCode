using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp13
{
    public class SimpleMath
    {

        public static (int result, int remainder) Divide(int dividend, int divisor)
        {
            int result = dividend / divisor;
            int remainder = dividend % divisor;
            return (result, remainder);
        }
        private static void UseALibrary()
        {
            var t = SimpleMath.Divide(5, 3);
            Console.WriteLine($"{t.result},{t.remainder}");
        }

        private static void TupleNames()
        {
            var t1 = Divide(9, 4);
            Console.WriteLine($"{t1.result},{t1.remainder}");
            (int res, int rem) t2 = Divide(11, 3);
            Console.WriteLine($"{t2.res}{t2.rem}");

            var t3 = (res: t1.result, rem: t1.remainder);
            var t4 = (t1.result, t1.remainder);
            Console.WriteLine($"{t4.result},{t4.remainder}");
        }

        static void TuplesWithLinkedList()
        {
            Console.WriteLine(nameof(TuplesWithLinkedList));
            var list = new LinkedList<int>(Enumerable.Range(0, 10));
            int value;
            LinkedListNode<int> node = list.First;
            do
            {
                (value, node) = (node.Value, node.Next);
                Console.WriteLine(value);
            } while (node != null);
            Console.WriteLine();
        }

        static void UsingAnonymousTypes()
        {
            var racerNamesAndStarts = Formulal.GetChampions().Where(r => r.Country == "Italy").OrderByDescending(r => r.Wins).Select(r => new { r.LastName, r.Starts });
            foreach (var r in racerNamesAndStarts)
            {
                Console.WriteLine($"{r.LastName},Starts:{r.Starts}");
            }
        }

        static void UsingTuples()
        {
            var racerNamesAndStarts = Formulal.GetChampions().Where(r => r.Country == "Italy").OrderByDescending(r => r.Wins).Select(r => {
                r.LastName,
                r.Starts
            });
            foreach (var r in racerNamesAndStarts)
            {
                Console.WriteLine($"{r.LastName},{r.Starts}");
            }
        }

        private static void Deconstruct()
        {
            var p1 = new Person("katharina", "nage1");
            (var first, var last) = p1;
            Console.WriteLine($"{first}{last}");
        }

    }
}
