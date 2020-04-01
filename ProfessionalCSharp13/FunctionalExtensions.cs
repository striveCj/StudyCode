using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp13
{
    public static class FunctionalExtensions
    {
        public static void Use<T>(this T item,Action<T> action)where T : IDisposable
        {
            using (item)
            {
                action(item);
            }
        }
    }
}
