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
            if (priority>9||priority<0)
            {
                throw new ArgumentException("Priority must be between 0 and 9");
            }
            if (_priorityNodes[priority].Value==null)
            {
                --priority;
                if (priority<=0)
                {
                    AddDocmentToPriorityNode(doc,priority);
                }
                else
                {
                    _documentList.AddLast(doc);
                    _priorityNodes[doc.Priority] = _documentList.Last;
                }
                return;
            }
            else
            {
                LinkedListNode<Document> prioNode = _priorityNodes[priority];
                if (priority==doc.Priority)
                {
                    _documentList.AddAfter(prioNode, doc);
                    _priorityNodes[doc.Priority] = prioNode.Next;
                }
                else
                {
                    LinkedListNode<Document> firstPriNode = prioNode;
                    while (firstPriNode.Previous!=null&&firstPriNode.Previous.Value.Priority==prioNode.Value.Priority)
                    {
                        firstPriNode = prioNode.Previous;
                        prioNode = firstPriNode;
                    }
                    _documentList.AddBefore(firstPriNode, doc);
                    _priorityNodes[doc.Priority] = firstPriNode.Previous;
                }
            }

        }

        public void DisplayAllNodes()
        {
            foreach (var  doc in _documentList)
            {
                Console.WriteLine(doc.Priority);
                Console.WriteLine(doc.Title);
            }
        }

        public Document GetDocument()
        {
            Document doc = _documentList.First.Value;
            _documentList.RemoveFirst();
            return doc;
        }
    }
}
