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

}
