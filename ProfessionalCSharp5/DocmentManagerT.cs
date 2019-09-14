using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp5
{
       public   class DocmentManagerT<T> where T:IDocument
    {

        private  readonly  Queue<T> _docmentQueue=new Queue<T>();
        private  readonly  object _lockQueue=new object();

        public void AddDocument(T doc)
        {
            lock (_lockQueue)
            {
                _docmentQueue.Enqueue(doc);
            }
        }

        public bool IsDocumentAvailable => _docmentQueue.Count > 0;

        public T GetDocment()
        {
            T doc = default;
            lock (_lockQueue)
            {
                doc = _docmentQueue.Dequeue();
            }
            return doc;
        }

        public void DisplayAllDocument()
        {
            foreach (T doc in _docmentQueue)
            {
                Console.WriteLine(doc.Title);
            }
        }
    }

    public class Document : IDocument
    {
        public Document(string title, string content)
        {
            Title = title;
            Content = content;
        }

        public string Title { get; }
        public string Content { get; }


    }
}
