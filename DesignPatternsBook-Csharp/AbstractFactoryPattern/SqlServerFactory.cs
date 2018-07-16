using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsBook_Csharp.AbstractFactoryPattern
{
    class SqlServerFactory:IFactory
    {
        public IUser CreateUser()
        {
            return new SqlserverUser();
        }

        public IDepartment CreateDepartment()
        {
            return new SqlServerDepartment();
        }
    }
}
