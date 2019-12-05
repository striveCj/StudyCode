using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp10
{
    class Program
    {
        //static  async Task Main()
        //{
        //    //var intList = new List<int>();
        //    var racers=new List<Racer>();
        //    List<int> intList=new List<int>(10);
        //    intList.Capacity = 20;
        //    intList.TrimExcess();
        //    var intList2=new List<int>();
        //    intList2.Add(1);
        //    intList2.Add(2);
        //    var stringList=new List<string>();
        //    stringList.Add("one");
        //    stringList.Add("two");

        //    var  graham=new Racer(7,"Graham","Hill","UK",14);
        //    var emerson = new Racer(7, "Graham", "Hill", "UK", 14);
        //    var mario = new Racer(7, "Graham", "Hill", "UK", 14);
        //    var racers2 = new List<Racer>(20){ graham,emerson,mario};
        //    racers2.Add(new Racer(24,"a","b","c",25));
        //    racers2.Add(new Racer(21,"a","b","c",22));
        //    racers2.Insert(3,new Racer(6,"Pjil","Hill","USA",3));
        //    racers2.RemoveAt(3);
        //    int index = racers2.IndexOf(mario);
        //    RacerComparer racerComparer = new RacerComparer(RacerComparer.CompareType.Country);
        //    racers2.Sort(racerComparer);


        //    var dm=new DocumentManager();
        //    Task processDocuments = ProcessDocuments.Start(dm);
        //    for (int i = 0; i < 1000; i++)
        //    {
        //        var doc=new Document($"Doc{i.ToString()}","content");
        //        dm.AddDocument(doc);
        //        Console.WriteLine(doc.Title);
        //        await Task.Delay(new Random().Next(20));

        //    }
        //    await processDocuments;
        //    Console.ReadLine();

        //    var alphabet = new Stack<char>();
        //    alphabet.Push('A');
        //    alphabet.Push('B');
        //    alphabet.Push('C');
        //    foreach (char item in alphabet)
        //    {
        //        Console.WriteLine(item);
        //    }
        //    Console.WriteLine();

        //    while (alphabet.Count>0)
        //    {
        //        Console.WriteLine(alphabet.Pop());
        //    }
        //    Console.WriteLine();

        //    var pdm=new PriorityDocumentManager();
        //    pdm.AddDocument(new Document("a","b",1));

        //    pdm.AddDocument(new Document("a", "b", 2));
        //    pdm.AddDocument(new Document("a", "b", 3));
        //    pdm.AddDocument(new Document("a", "b", 4));
        //    pdm.AddDocument(new Document("a", "b", 5));
        //    pdm.DisplayAllNodes();

        //    #region 有序列表
        //    var books=new SortedList<string, string>();
        //    books.Add("a","1");
        //    books.Add("b","2");
        //    books.Add("c","3");
        //    books["d"] = "4";
        //    foreach (var book in books)
        //    {
        //        Console.WriteLine($"{book.Key},{book.Value}");
        //    }
        //    foreach (var title in books.Keys)
        //    {
        //        Console.WriteLine(title);
        //    }


        //    #endregion
        //}

        static void Main()
        {
            var idJimmie=new EmployeeId("C48");
            var jimmie=new Employee(idJimmie,"Jimmie Johnson",150926.00m);

            var idJoey=new EmployeeId("F22");
            var joey=new Employee(idJoey,"Joey Logano",45125.00m);

            var employees=new Dictionary<EmployeeId,Employee>(31)
            {
                [idJimmie]=jimmie,
                [idJoey]=joey
            };
            foreach (var employee in employees.Values)
            {
                Console.WriteLine(employee);
            }

            while (true)
            {
                Console.WriteLine("Enter employee id (X to exit)> ");
                var userInput = Console.ReadLine();
                userInput = userInput.ToUpper();
                if (userInput=="X") break;
                EmployeeId id;
                try
                {
                    id=new EmployeeId(userInput);
                    if (!employees.TryGetValue(id,out Employee employee))
                    {
                        Console.WriteLine($"{id} 不存在");
                    }
                    else
                    {
                        Console.WriteLine(employee);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    
                }
                {
                    
                }
            }
        }
    }

}
