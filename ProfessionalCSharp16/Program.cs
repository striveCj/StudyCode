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
        static void Main(string[] args)
        {
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
    }
}
