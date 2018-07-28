using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsBook_Csharp.InterpreterPattern
{
    class Context
    {
        private string input;
        public string Input
        {
            get { return input; }
            set { input = value; }
        }

        private string output;
        public string Output
        {
            get { return output; }
            set { output = value; }
        }
    }
}
