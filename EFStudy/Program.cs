using EFStudy.Core;
using EFStudy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFStudy
{
    class Program
    {
        static void Main(string[] args)
         {
            using (var efDbContext=new EfDbContext())
            {
                var customer = new Customer
                {
                    Name = "chenjie",
                    Email = "530216775@q.com",
                    CreatedTime = DateTime.Now,
                    ModifiedTime = DateTime.Now,
                    Orders = new List<Order>
                {
                    new Order
                    {
                        Quanatity=12,
                        Price=1500,
                        CreatedTime=DateTime.Now,
                    ModifiedTime=DateTime.Now
                    },new Order
                    {
                        Quanatity=10,
                        Price=2500,
                        CreatedTime=DateTime.Now,
                        ModifiedTime=DateTime.Now
                    }
                }
                };
                efDbContext.Customer.Add(customer);
                efDbContext.SaveChanges();
                //efDbContext.Blogs.Add(new Model.Blog()
                //{
                //    Name = "陈杰",
                //    Url = "http://www.cnblogs.com/chen-jie"
                //});
                //efDbContext.SaveChanges();
                //var query = (from b in efDbContext.BullingDetails.OfType<BankAccount>() select b).ToList();

                //var users = new User
                //{
                //    BirthDate = DateTime.Now,
                //    CreatedTime = DateTime.Now,
                //    ModifiedTime = DateTime.Now,
                //    Name = "chenjie",
                //    IDNumber = "46031399108274789"
                //};
                //efDbContext.User.Add(users);
                //efDbContext.SaveChanges();

                //var user = efDbContext.User.Find(1);
                ////原始值
                //var originaValues = efDbContext.Entry(user).ComplexProperty(u => u.Address).OriginalValue;
                ////当前值
                //var currentValues = efDbContext.Entry(user).ComplexProperty(u => u.Address).CurrentValue;

            }
        }
    }
}
