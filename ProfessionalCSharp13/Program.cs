using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp13
{
   static class Program
    {
        static void Main(string[] args)
        {
            using (var r = new Resource())
            {
                r.Foo();
            }
        }

        private static void YieldSampleSimple()
        {
            try
            {
                string[] names = { "James", "Niki", "John", "Grhard", "Jack" };
                var q = names.Where1(null);
                foreach (var item in q)
                {
                    Console.WriteLine(item);
                }
            }
            catch (ArgumentNullException ex)
            {

                Console.WriteLine(ex);
            }
            Console.WriteLine();
        }
        private static void IntroWithLambadExpression()
        {
            Func<int, int, int> add = (x, y) => { return x + y; };
            int result = add(37, 5);
            Console.WriteLine(result);
        }

        private static void IntroWithLocalFunctions()
        {
            int add(int x,int y)
            {
                return x + y;
            }
            int result = add(37, 5);
            Console.WriteLine(result);
        }

        private static void IntroWithLocalFunctionWithClosures()
        {
            int z = 3;
            int result = add(37, 5);
            Console.WriteLine(result);

            int add(int x, int y) => x + y + z;
        }

        private static IEnumerable<T> Where1<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source==null)
            {
                throw new ArgumentException(nameof(source));
            }
            if (predicate==null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            foreach (T item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        private static IEnumerable<T> Where2<T>(this IEnumerable<T> source,Func<T,bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
                if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            return Where2Impl(source, predicate);
        }

        private static IEnumerable<T> Where2Impl<T>(IEnumerable<T> source, Func<T,bool> predicate)
        {
            foreach (T item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        private static void YieldSampleWithPrivateMethod()
        {
            Console.WriteLine(nameof(YieldSampleWithPrivateMethod));
            try
            {
                string[] names =["James", "Niki", "John", "Gerhard", "Jack"];
                var q = names.Where2(null);
                foreach (var n in q)
                {
                    Console.WriteLine(q);
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        private static IEnumerable<T> Where3<T>(this IEnumerable<T> source,Func<T,bool> predicate)
        {
            if (source==null)
            {
                throw new ArgumentNullException(nameof(source));

            }
            if (predicate==null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            return Iterator();

            IEnumerable<T> Iterator()
            {
                foreach (T item in source)
                {
                    if (predicate(item))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
