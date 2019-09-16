using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp5
{
    public class Shape
    {
        public double Width { get; set; }
        public  double Height { get; set; }
        public override string ToString()
        {
            return $"Width:{Width},Height:{Height}";
        }
    }

    public class Rectangle : Shape
    {
        
    }

   public interface IIndex<out T>
    {
        T this[int indx] { get; }
        int Count { get; }
    }

    public class RectangleCollection : IIndex<Rectangle>
    {
        private Rectangle[] data=new Rectangle[3]
        {
            new Rectangle{Height = 2,Width = 5},
            new Rectangle{Height = 3,Width = 7},
            new Rectangle{Height = 4.5,Width=2.9}
        };

        private static RectangleCollection _coll;
        public static RectangleCollection GetRectangles() => _coll ?? (_coll = new RectangleCollection());

        public Rectangle this[int index]
        {
            get
            {
                if (index<0||index>data.Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                   
                }
                return data[index];
            }
        }

        public int Count => data.Length;
    }

    public interface IDisplay<in T>
    {
        void Show(T item);
    }

    public class ShapeDisplay : IDisplay<Shape>
    {
        public void Show(Shape s) => Console.WriteLine($"{s.GetType().Name}Width：{s.Width},Height:{s.Height}");
    }
}
