using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsBook_Csharp.InterpreterPattern
{
    class NoterminalExpression:AbstractExpression
    {
        public override void Interprent(Context context)
        {
            Console.WriteLine("非终端解释器");
        }
    }
}
