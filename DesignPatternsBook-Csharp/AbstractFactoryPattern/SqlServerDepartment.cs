using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsBook_Csharp.AbstractFactoryPattern
{
    class SqlServerDepartment:IDepartment
    {
        public void Insert(Department department)
        {
            Console.WriteLine("在SQL Server中给Department表增加一条记录");
        }

        public Department GetDepartment(int id)
        {
            Console.WriteLine("在SQLServer中更具ID得到Department表一条记录");
            return null;
        }
    }
}
