using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsBook_Csharp.ProxyPattern
{
     class RealSubject:Subject
    {
        public override void Request()
        {
            Console.WriteLine("真实的请求");
        }
    }
}
