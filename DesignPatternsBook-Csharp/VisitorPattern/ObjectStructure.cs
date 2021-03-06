﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsBook_Csharp.VisitorPattern
{
    class ObjectStructure
    {
        private IList<Element> elements = new List<Element>();
        public void Attach(Element element)
        {
            elements.Add(element);
        }

        public void Detach(Element element)
        {
            elements.Remove(element);
        }
        public void Accept(Visitor visitor)
        {
            foreach (var e in elements)
            {
                e.Accept(visitor);
            }
        }
    }
}
