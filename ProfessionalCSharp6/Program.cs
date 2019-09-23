using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp6
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector vect1, vect2, vect3;
            vect1=new Vector(3,3,1);
            vect2=new Vector(2,-4,-4);
            vect3 = vect1 + vect2;
            Console.WriteLine(vect1);
            Console.WriteLine(vect2);
            Console.WriteLine(vect3);
        }
        static void SimpleCalculations()
        {
            Console.WriteLine(nameof(SimpleCalculations));
            uint binary1 = 0b1111_0000_1100_0011_1110_0001_0001_1000;
            uint binary2 = 0b0000_1111_1100_0011_0101_1010_1110_0111;
            uint binaryAnd = binary1 & binary2;
            DisplayBits("AND",binaryAnd,binary1,binary2);
            uint binaryOR = binary1 | binary2;
            DisplayBits("OR", binaryAnd, binary1, binary2);
            uint binaryXOR = binary1 ^ binary2;
            DisplayBits("XOR", binaryAnd, binary1, binary2);
            uint reverse1 = ~binary1;
            DisplayBits("NOT",reverse1,binary1);
            Console.WriteLine();
        }

        static void DisplayBits(string title, uint result, uint left, uint? right = null)
        {
            Console.WriteLine(title);
            Console.WriteLine(left.ToBinaryString().AddSeparators());
            if (right.HasValue)
            {
                Console.WriteLine(right.Value.ToBinaryString().AddSeparators());
            }
            Console.WriteLine(result.ToBinaryString().AddSeparators());
            Console.WriteLine();
        }


    }
}
