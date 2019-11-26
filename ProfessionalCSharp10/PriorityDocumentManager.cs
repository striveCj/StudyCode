using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp10
{
    public class PriorityDocumentManager
    {
        private readonly LinkedList<Document> _documentList;
        private readonly List<LinkedListNode<Document>> _priorityNodes;

        public PriorityDocumentManager()
        {
            _documentList=new LinkedList<Document>();
            _priorityNodes=new List<LinkedListNode<Document>>(10);
            for (int i = 0; i < 10; i++)
            {
                _priorityNodes.Add(new LinkedListNode<Document>(null));
            }
        }

        public void AddDocument(Document d)
        {
            if (d==null)
            {
                throw new ArgumentNullException(nameof(d));
            }
            AddDocmentToPriorityNode(d,d.Priority);
        }

        public void AddDocmentToPriorityNode(Document doc, int priority)
        {
            
        }
    }
}
