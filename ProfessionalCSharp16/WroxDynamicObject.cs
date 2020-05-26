using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp16
{
    public class WroxDynamicObject:DynamicObject
    {
        private Dictionary<string, object> _dynamicData = new Dictionary<string, object>();

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            bool success = false;
            result = null;
            if (_dynamicData.ContainsKey(binder.Name))
            {
                result = _dynamicData[binder.Name];
                success = true;
            }
            else
            {
                result = "Property Not Found";
            }
            return success;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            _dynamicData[binder.Name] = value;
            return true;
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            dynamic method = _dynamicData[binder.Name];
            result = method((DateTime)args[0]);
            return result!= null;
        }

        static void DoExpando()
        {
         
            dynamic expObj = new ExpandoObject();
            expObj.FirstName = "Daffy";
            expObj.LastName = "Duck";
            Console.WriteLine($"{expObj.FirstName}{expObj.LastName}");
            Func<DateTime, string> GetTomorrow =today=> today.AddDays(1).ToShortDateString();

            expObj.GetTomorrowDate = GetTomorrow;
            Console.WriteLine($"Tomorrow is {expObj.GetTomorrowDate(DateTime.Now)}");
            expObj.Friends = new List<Person>();
            expObj.Friends.Add(new Person() { FirstName = "Bob", LastName = "Jones" });
            expObj.Friends.Add(new Person() { FirstName = "Robert", LastName = "Jones" });
            expObj.Friends.Add(new Person() { FirstName = "Bobby", LastName = "Jones" });

            foreach (var item in expObj)
            {
                Console.WriteLine($"{item.FirstName}{item.LastName}");
            }
        }
    }
}
