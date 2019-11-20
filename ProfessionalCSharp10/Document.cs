using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp10
{
    public class Document
    {
        public string Title { get; }
        public string Content { get; }

        public Document(string title, string content)
        {
            Title = title;
            Content = content;
        }
    }
}
