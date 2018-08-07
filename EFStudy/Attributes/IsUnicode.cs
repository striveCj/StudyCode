using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFStudy.Attributes
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple =false)]
    internal class IsUnicode:Attribute
    {
        public bool Unicode { get; set; }

        public IsUnicode(bool isUnicode)
        {
            Unicode = isUnicode;
        }
    }
}
