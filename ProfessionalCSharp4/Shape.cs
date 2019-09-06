using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp4
{
    public class Shape
    {
        public Position Position { get; }=new Position();
        public Size Size { get; }=new Size();
        public virtual void Draw() => Console.WriteLine($"{Position}和{Size}");

        public void MoveBy(int x, int y)
        {
        }

        public virtual void Move(Position newPosition)
        {
            Position.X += newPosition.X;
            Position.Y += newPosition.Y;
            Console.WriteLine($"moves to{Position}");
        }
    }

    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class Size
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class Rectangle : Shape
    {
        public override void Draw() => Console.WriteLine($"{Position}and{Size}");

        public override void Move(Position newPosition)
        {
            Console.WriteLine("Rectangle");
            base.Move(newPosition);
        }


    }

    public class Ellipse : Shape
    {
        public new void MoveBy(int x, int y)
        {
            Position.X += x;
            Position.Y += y;
        }
    }
}
