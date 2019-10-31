using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp8
{
    class Program
    {
        static void Main(string[] args)
        {
            //int x = 40;
            //GetAString firstStringMethod=new GetAString(x.ToString);
            //Console.WriteLine($"String is {firstStringMethod}");

            //int x = 40;
            //GetAString firstStringMethod = x.ToString;
            //Console.WriteLine($"{firstStringMethod}");
            //var balance=new Currency(34,50);
            //firstStringMethod = balance.ToString;
            //Console.WriteLine($"{firstStringMethod}");
            //firstStringMethod=new GetAString(Currency.GetCurrencyUnit);
            //Console.WriteLine($"{firstStringMethod}");

            //DoubleOp[] operations =
            //{
            //    MathOperations.MultiplyByTwo,
            //    MathOperations.Square
            //};
            //for (int i = 0; i < operations.Length; i++)
            //{
            //    Console.WriteLine($"Using operations[{i}]");
            //    ProcessAndDisplayNumber(operations[i], 2.0);
            //    ProcessAndDisplayNumber(operations[i], 7.94);
            //    ProcessAndDisplayNumber(operations[i],1.414);
            //    Console.WriteLine();
            //}

            //Employee[] employees =
            //{
            //    new Employee("a", 20000),
            //    new Employee("b",20000),
            //    new Employee("c",20000),
            //    new Employee("d",20000),
            //    new Employee("e",20000),
            //};
            //BubbleSorter.Sort(employees,Employee.CompareSalary);
            //foreach (var employee in employees)       {
            //    Console.WriteLine(employee);
            //}
            Action<double> operation = MathOperations.MultiplyByTwo;
            operation += MathOperations.Square;
            ProcessAndDisplayNumber(operation,2.0);
            ProcessAndDisplayNumber(operation, 7.94);
            ProcessAndDisplayNumber(operation, 1.414);
            Console.WriteLine();

        }

        static void ProcessAndDisplayNumber(Action<double> action, double value)
        {
            Console.WriteLine();
            Console.WriteLine(value);
            action(value);
        }

        static void ProcessAndDisplayNumber(DoubleOp action, double value)
        {
            double result = action(value);
            Console.WriteLine($"Value is {value},result of operation is {result}");
        }
        private delegate string GetAString();

        delegate double DoubleOp(double x);
    }
}
