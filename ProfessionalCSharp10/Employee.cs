using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp10
{
    public class Employee
    {
        private string _name;
        private decimal _salary;
        private readonly EmployeeId _id;

        public Employee(EmployeeId id, string name, decimal salary)
        {
            _id = id;
            _name = name;
            _salary = salary;
        }

        public override string ToString()
        {
            return $"{_id.ToString()}:{_name,-20}{_salary:C}";
        }
    }
}
