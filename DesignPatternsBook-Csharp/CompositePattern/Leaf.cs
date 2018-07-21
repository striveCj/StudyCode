using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsBook_Csharp.CompositePattern
{
    class Leaf:Component
    {
        public Leaf(string name) : base(name)
        {

        }
        public override void Add(Component c)
        {
            Console.WriteLine("Add to a Leaf");
        }

        public override void Remove(Component c)
        {
            Console.WriteLine("Remove to a Leaf");
        }
        public override void Display(int depth)
        {
            Console.WriteLine(new String('-',depth)+name);
        }
    }
}
