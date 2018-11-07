using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreStart.Core;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace EFCoreStart
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new EFCoreDbContext();
            //TODO:EFCode不知道是否要创建，所以要手动去创建   
            context.Database.EnsureCreated();
            context.Database.EnsureDeleted();
            //TODO:手动调用EntityFramework Core内置API创建
            RelationalDatabaseCreator databaseCreator =
                (RelationalDatabaseCreator) context.Database.GetService<IDatabaseCreator>();
            databaseCreator.CreateTables();
            var student = context.Students.FirstOrDefault();




        }
    }
}
