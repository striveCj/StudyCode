using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsBook_Csharp.AbstractFactoryPattern
{
    class AccessUser : IUser
    {
        public void Insert(User user)
        {
            Console.WriteLine("在Sql中给Access表增加一条记录");
        }
        public User GetUser(int Id)
        {
            Console.WriteLine("在SQL中得到一条Access表记录");
            return null;
        }
    }
}
