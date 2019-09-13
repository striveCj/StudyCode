using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp5
{
       public   class DocmentManagerT<T>
    {

        private  readonly  Queue<T> _docmentQueue=new Queue<T>();
        private  readonly  object _lockQueue=new object();

        public void ASddDocument(T doc)
        {
            lock (_lockQueue)
            {
                _docmentQueue.Enqueue(doc);
            }
        }

        public bool IsDocumentAvailable => _docmentQueue.Count > 0;
    }
}
