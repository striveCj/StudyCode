using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp5
{
    public class LinkedListNode
    {
        public LinkedListNode(object value) => Value = value;
        public  object Value { get; }
        public LinkedListNode Next { get; internal set; }
        public LinkedListNode Prev { get; internal set; }
    }

    public class LinkedList : IEnumerable
    {
        public LinkedListNode First { get; private set; }

        public LinkedListNode Last { get; private set; }

        public LinkedListNode AddLast(object node)
        {
            var newNode=new LinkedListNode(node);
            if (First==null)
            {
                First = newNode;
                Last = First;
            }
            else
            {
                LinkedListNode previous = Last;
                Last.Next = newNode;
                Last = newNode;
                Last.Prev = previous;
            }
            return newNode;
        }

        public IEnumerator GetEnumerator()
        {
            LinkedListNode current = First;
            while (current!=null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }
    }

    public class LinkedListNode<T>
    {
        public LinkedListNode()
        {
        }

        public LinkedListNode(T value)=>Value=value;
        public  T Value { get; }
        public LinkedListNode<T> Next { get; internal set; }

        public  LinkedListNode<T> Prev { get; internal set; }
    }

    public class LinkedList<T> : IEnumerable<T>
    {
        public LinkedListNode<T> First { get; private set; }

        public LinkedListNode<T> Last { get; private set; }

        public LinkedListNode<T> AddLast(T node)
        {
            var newNode = new LinkedListNode<T>(node);
            if (First == null)
            {
                First = newNode;
                Last = First;
            }
            else
            {
                LinkedListNode<T> previous = Last;
                Last.Next = newNode;
                Last = newNode;
                Last.Prev = previous;
            }
            return newNode;
        }

        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> current = First;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
