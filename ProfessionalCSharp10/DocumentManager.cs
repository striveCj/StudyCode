using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp10
{
    public class DocumentManager
    {
        private readonly  object _syncQueue=new object();
        private readonly Queue<Document> _documentQueue=new Queue<Document>();

        public void AddDocument(Document doc)
        {
            lock (_syncQueue)
            {
                _documentQueue.Enqueue(doc);
            }
        }

        public Document GetDocument()
        {
            Document Doc = null;
            lock (_syncQueue)
            {
                Doc = _documentQueue.Dequeue();
            }
            return Doc;
        }

        public bool IsDocumentAvailable => _documentQueue.Count > 0;
    }
}
