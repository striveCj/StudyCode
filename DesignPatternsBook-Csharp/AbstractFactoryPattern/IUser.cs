using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsBook_Csharp.AbstractFactoryPattern
{
    interface IUser
    {
        void Insert(User user);
        User GetUser(int id);
    }
}
