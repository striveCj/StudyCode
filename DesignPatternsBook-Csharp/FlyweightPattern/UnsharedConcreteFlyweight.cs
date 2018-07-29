using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsBook_Csharp.FlyweightPattern
{
    class UnsharedConcreteFlyweight:Flyweight
    {
        public override void Operation(int extrinsicstate)
        {
            Console.WriteLine($"不共享具体的Flyweight{extrinsicstate}");
        }
    }
}
