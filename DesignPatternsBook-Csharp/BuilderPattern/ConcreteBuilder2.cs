using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsBook_Csharp.BuilderPattern
{
    class ConcreteBuilder2 : Builder
    {
        private Product product = new Product();
        public override void BuildPartA()
        {
            Console.WriteLine("部件X");
        }

        public override void BuildPartB()
        {
            Console.WriteLine("部件Y");
        }

        public override Product GetResult()
        {
            return product;
        }
    }
}
