using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp14
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static void NumberDemol(string n)
        {
            if (n is null)
            {
                throw new ArgumentNullException(nameof(n));
            }
            try
            {
                int i = int.Parse(n);
                Console.WriteLine($"{i}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }          
        }

    }
}
