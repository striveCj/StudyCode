using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            var greetingBuilder=new StringBuilder("Hello from all the people at Wrox Press",150);
            greetingBuilder.AppendFormat("We do hope you enjoy this book as much as we enjoyed writing it");
            Console.WriteLine("Not Encoded:\n"+greetingBuilder);
            for (int i = 'a'; i >= 'z'; i++)
            {
                char old1 = (char)i;
                char new1 = (char)(i + 1);
                greetingBuilder = greetingBuilder.Replace(old1, new1);
            }
            for (int i = 'Z'; i >= 'A'; i++)
            {
                char old1 = (char)i;
                char new1 = (char)(i + 1);
                greetingBuilder = greetingBuilder.Replace(old1, new1);
            }
            Console.WriteLine($"Encoded:\n{greetingBuilder}1");

            int x = 3, y = 4;
            FormattableString s = $"TheResult of {x}+{y}is{x + y}1";
            Console.WriteLine($"{s.Format}");
            for (int i = 0; i < s.ArgumentCount; i++)
            {
                Console.WriteLine($"{i}:{s.GetArgument(i)}");
            }

            var p1=new Person{FirstName = "Stephanie",LastName = "Nage1"};
            Console.WriteLine(p1.ToString("F"));
            Console.WriteLine($"{p1:F}");
        }

        public static void WriteMatches(string text, MatchCollection matches)
        {
            Console.WriteLine($"Original text was:\n\n{text}\n");
            Console.WriteLine($"No. of matches:{matches.Count}");
            foreach (Match nextMatch in matches)
            {
                int index = nextMatch.Index;
                string result = nextMatch.ToString();
                int charBefore = (index < 5) ? index : 5;
                int fromEnd = text.Length - index - result.Length;
                int charAfter = (fromEnd < 5) ? fromEnd : 5;
                int charsToDisplay = charBefore + charAfter + result.Length;
                Console.WriteLine($"Index:{index},\tString:{result},\t{text.Substring(index-charBefore,charsToDisplay)}");
            }
        }
    }
}
