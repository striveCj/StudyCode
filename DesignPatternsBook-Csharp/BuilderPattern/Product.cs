using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsBook_Csharp.BuilderPattern
{
    class Product
    {
        IList<string> parts = new List<string>();
        public void Add(string part)
        {
            parts.Add(part);
        }
        public void Show()
        {
            Console.WriteLine("\n产品创建------");
            foreach (string part in parts)
            {
                Console.WriteLine(part);
            }
        }
    }
}
