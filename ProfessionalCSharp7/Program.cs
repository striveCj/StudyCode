using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public IEnumerator<string> GetEnumerator()
        {
            yield return "Hello";
            yield return "World";
        }
    }
}
