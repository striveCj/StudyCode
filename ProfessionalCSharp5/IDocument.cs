using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp5
{
    public interface IDocument
    {
        string Title { get; }
        string Content { get; }
    }
}
