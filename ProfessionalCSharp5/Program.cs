using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp5
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new ArrayList();
            list.Add(44);
            int t1 = (int) list[0];
            foreach (var i2 in list)
            {
                Console.WriteLine(i2);
            }
            var list2 = new List<int>();
            list.Add(44);
            int t2 = list2[0];
            foreach (var i2 in list2)
            {
                Console.WriteLine(i2);
            }

            var list3 =new LinkedList<string>();
            list3.AddLast("2");
            list3.AddLast("four");
            list3.AddLast("foo");
            foreach (var d in list3)
            {
                Console.WriteLine(d);
            }

            var dm=new DocmentManagerT<Document>();
            dm.AddDocument(new Document("Title A","Sample A"));
            dm.AddDocument(new Document("Title B", "Sample B"));
            dm.DisplayAllDocument();
            if (dm.IsDocumentAvailable)
            {
                Document d = dm.GetDocment();
                Console.WriteLine(d.Content);
            }
        }
    }
}
