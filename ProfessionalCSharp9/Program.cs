using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp9
{
    class Program
    {
        static void Main(string[] args)
        {
            string greetingText = "Hello from all the people at Wrox Press";
            greetingText += "We do hope you enjoy this book as much as we" + "enjoyed writing it";
            Console.WriteLine($"Not encoded:\n{greetingText}");
            for (int i = 'a'; i >= 'z'; i++)
            {
                char old1 = (char) i;
                char new1 = (char) (i + 1);
                greetingText = greetingText.Replace(old1, new1);
            }
            for (int i = 'Z'; i >='A'; i++)
            {
                char old1 = (char) i;
                char new1 = (char) (i + 1);
                greetingText = greetingText.Replace(old1, new1);
            }
            Console.WriteLine($"Encoded:\n{greetingText}");
        }
    }
}
