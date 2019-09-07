using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp4
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape r=new Shape();
            DrawShape(r);
            Shape1 r1=new Ellipse1();
            DrawShape(r1);
        }

        public static void DrawShape(Shape shape) => shape.Draw();
        public static void DrawShape(Shape1 shape) => shape.Draw();
    }
}
