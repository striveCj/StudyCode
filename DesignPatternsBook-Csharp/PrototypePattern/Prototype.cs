using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsBook_Csharp.PrototypePattern
{
    abstract class Prototype
    {
        private string id;
        public Prototype(string id)
        {
            this.id = id;
        }
        public string Id
        {
            get { return id; }
        }

        public abstract Prototype Clone();
    }
}
