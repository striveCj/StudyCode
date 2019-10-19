using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System;

namespace ProfessionalCSharp7
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] names =
            //{
            //    "Christina Aguilera",
            //    "Shakira",
            //    "Beyonce",
            //    "Lady Gaga"
            //};
            //Array.Sort(names);
            //foreach (var name in names)         {
            //    Console.WriteLine(names);
            //}

            //Person[] beatles =
            //{
            //    new Person {FirstName = "a", LastName = "b"},
            //    new Person {FirstName = "a", LastName = "b"}
            //};
            //Person[] batelesClone = (Person[]) beatles.Clone();

            //Person[] persons =
            //{
            //    new Person("Damon", "Hill"),
            //    new Person("Niki", "Lauda"),
            //    new Person("Ayrton", "Senna"),
            //    new Person("Graham", "Hill"),
            //};
            //Array.Sort(persons);
            //foreach (var p in persons)
            //{
            //    Console.WriteLine(p);
            //}

            var titles=new MusicTitles();
            foreach (var title in titles)
            {
                Console.WriteLine(title);
            }
            Console.WriteLine();
            Console.WriteLine("reverse");
            foreach (var title in titles.Reverse())
            {
                Console.WriteLine(title);
            }
            Console.WriteLine();
            Console.WriteLine("sunset");
            foreach (var title in titles.Subset(2,2))
            {
                Console.WriteLine(title);
            }

            var game=new GameMoves();
            IEnumerator enumerator = game.Cross();
            while (enumerator.MoveNext())
            {
                enumerator=enumerator.Current as IEnumerator;
               
            }

             var janet=new Person2(1,"Janet","Jackson");
            Person2[] people1 =
            {
                new Person2(1, "2", "3"),
                janet
            };
            Person2[] people2 =
            {
                new Person2(1, "2", "3"),
                janet
            };
            if (people1!=people2)
            {
                Console.WriteLine("not same content");；
            }

        }

        public void HelloWorld()
        {
            var helloCollection=new HellCollection();
            foreach (var s in helloCollection)
            {
                Console.WriteLine(s);
            }
        }

        private static Span<int> IntroSpans()
        {
            int[] arr1 = {1, 4, 5, 11, 13, 18};
            var span1=new Span<int>(arr1);
            span1[1] = 11;
            Console.WriteLine($"arr1[1] is changed via span1[1]：{arr1[1]}");
            return span1;
        }

        private static Span<int> CreateSlices(Span<int> span1)
        {
            Console.WriteLine(nameof(CreateSlices));
            int[] arr2 = {3, 5, 7, 9, 11, 13, 15};
            var span2=new Span<int>(arr2);
            var span3=new Span<int>(arr2,start:3,length:3);
            var span4 = span1.Slice(start: 2, length: 4);
            return span2;
        }

        private static void DisplaySpan(string title, ReadOnlySpan<int> spar)
        {
            Console.WriteLine(title);
            for (int i = 0; i < spar.Length; i++)
            {
                Console.WriteLine($"{spar[i]}");
            }
            Console.WriteLine();
        }
    
    }



    public class HellCollection
    {
        public IEnumerator GetEnumerator()=>new Enumerator(0);

        public class Enumerator : IEnumerator<string>, IEnumerator, IDisposable
        {
            private int _state;
            private string _current;
            public Enumerator(int state) => _state = state;
            bool System.Collections.IEnumerator.MoveNext()
            {
                switch (_state)
                {
                    case 0:
                        _current = "Hello";
                        _state = 1;
                        return true;
                    case 1:
                        _current = "World";
                        _state = 2;
                        return true;
                    case 2:
                        break;

                }
                return false;
            }
            public void Dispose()
            {

            }



             void System.Collections.IEnumerator.Reset() => throw new NotImplementedException();


            string IEnumerator<string>.Current => _current;

            object IEnumerator.Current => _current;

        }


    }

    public class MusicTitles
    {
        private string[] names = {"Tubular Bells", "Hergest Ridge", "Ommadawn", "Platinum"};

        public IEnumerator<string> GetEnumerator()
        {
            for (int i = 0; i < 4; i++)
            {
                yield return names[i];
            }
        }

        public IEnumerable<string> Reverse()
        {
            for (int i = 3; i >=0; i--)
            {
                yield return names[i];
            }
        }

        public IEnumerable<string> Subset(int index, int length)
        {
            for (int i = 0; i < index+length; i++)
            {
                yield return names[i];
            }
        }
    }

    public class GameMoves
    {
        private IEnumerator _cross;
        private IEnumerator _circle;

        public GameMoves()
        {
            _cross = Cross();
            _circle = Circle();
        }

        private int _move = 0;
        private const int MaxMoves = 9;
        public IEnumerator Cross()
        {
            while (true)
            {
                Console.WriteLine($"Cross,move{_move}");
                if (++_move>=MaxMoves)
                {
                    yield break;
                }
                yield return _circle;
            }

        }

        public IEnumerator Circle()
        {
            while (true)
            {
                Console.WriteLine($"Circle,move{_move}");
                if (++_move>=MaxMoves)
                {
                    yield break;
                }
                yield return _cross;
            }
        }
    }
  

}
