using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp10
{
    public class EmployeeIdException:Exception
    {
        public EmployeeIdException(string message) : base(message) { }
    }

    public struct EmployeeId : IEquatable<EmployeeId>
    {
        private readonly char _prefix;
        private readonly int _number;

        public EmployeeId(string id)
        {
            if (id==null)throw new ArgumentNullException(nameof(id));
            _prefix = (id.ToUpper())[0];
            int numLength = id.Length - 1;
            try
            {
                _number = int.Parse(id.Substring(1,numLength>6?6:numLength));
            }
            catch (Exception e)
            {
                
                throw new EmployeeIdException("请格式化");
            }
        }

        public override string ToString() => _prefix.ToString()+$"{_number,6:00000}";
        public bool Equals(EmployeeId other)
        {
            return _prefix == other._prefix && _number == other._number;
        }

        public override bool Equals(object obj) => Equals((EmployeeId) obj);

        public override int GetHashCode() => (_number ^ _number << 16) * 0x15051505;

        public static bool operator ==(EmployeeId left, EmployeeId right) => left.Equals(right);

        public static bool operator !=(EmployeeId left, EmployeeId right) => !(left == right);

    }
}
