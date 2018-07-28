using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsBook_Csharp.InterpreterPattern
{
    class TerminalExpression:AbstractExpression
    {
        public override void Interprent(Context context)
        {
            Console.WriteLine("终端解释器");
        }
    }
}
