using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp16
{
    class Program
    {
        private static StringBuilder OutputText = new StringBuilder();
        private static DateTime backDateTo = new DateTime(2017, 2, 1);

        //Attribute supportsAttribute=Attribute.GetCustomAttributes()
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.Load(new AssemblyName("VectorClass"));
            Attribute supportsAttribute = assembly.GetCustomAttribute(typeof(SupportsAttribute));
        }

        static void AnalyzeType(Type t)
        {
            TypeInfo typeInfo = t.GetTypeInfo();
            AddToOutput(t.Name);
            AddToOutput(t.FullName);
            AddToOutput(t.Namespace);

            Type tBase = t.BaseType;
            if (tBase!=null)
            {
                AddToOutput(tBase.Name);
            }
            AddToOutput("\npublic members:");
            foreach (var item in t.GetMembers())
            {
                AddToOutput($"{item.DeclaringType}{item.MemberType}{item.Name}");
            }
        
        }

        static void AddToOutput(string Text) => OutputText.Append("\n" + Text);

        private const string CalculatorTypeName = "CalculatorLib.Calculator";
        public static void ShowUsage()
        {
            Console.WriteLine(nameof(ClientApp));
        }

        public static object GetCalculator()
        {
            Assembly assembly = Assembly.LoadFile(CalculatorLibPath);
            return assembly.CreateInstance(CalculatorTypeName);
        }

        private static void UsingReflection()
        {
            double x = 3;
            double y = 4;
            object calc = GetCalculator();
            object result = calc.GetType().GetMethod("Add").Invoke(calc,new object[] { x,y});
            Console.WriteLine($"{x}{y}{result}");
        }

        private static void ReflectionNew()
        {
            double x = 3;
            double y = 4;
            dynamic calc = GetCalculator();
            double result = calc.Add(x, y);
            Console.WriteLine($"{x}{y}{result}");
        }
    }
}
