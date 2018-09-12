using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFStudy.Model
{
    public partial class Customer:BaseEntity
    {
        public virtual string Name { get; set; }

        public virtual string Email { get; set; }

        //private  string PrivateAddress { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
    /// <summary>
    /// 私有化属性映射
    /// </summary>
    //public partial class Customer
    //{
    //    public class PrivatePropertyExtension
    //    {
    //        public static readonly Expression<Func<Customer,string>> test_private =p=>p.PrivateAddress;
    //    }
    //}
}
