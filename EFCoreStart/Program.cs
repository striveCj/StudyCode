using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreStart.Core;

namespace EFCoreStart
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new EFCoreDbContext();
            context.Database.EnsureCreated();
            var student = context.Students.FirstOrDefault();
        }
    }
}
