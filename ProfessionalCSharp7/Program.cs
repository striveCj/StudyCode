using System;
using System.Collections;
using System.Collections.Generic;

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


        }

        public void HelloWorld()
        {
            var helloCollection=new HellCollection();
            foreach (var s in helloCollection)
            {
                Console.WriteLine(s);
            }
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
  

}
