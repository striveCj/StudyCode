using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp3
{
    public static class StringExtension
    {
        public static int GetWordCount(this string s) => s.Split().Length;
    }
}
