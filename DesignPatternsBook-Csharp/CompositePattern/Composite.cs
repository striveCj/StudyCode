using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsBook_Csharp.CompositePattern
{
    class Composite : Component
    {
        private List<Component> Children = new List<Component>();
        public Composite(string name) : base(name)
        {

        }

        public override void Add(Component c)
        {
            Children.Add(c);
        }

        public override void Display(int depth)
        {
            foreach (var item in Children)
            {
                item.Display(depth+2);
            }
        }

        public override void Remove(Component c)
        {
            Children.Remove(c);
        }
    }
}
