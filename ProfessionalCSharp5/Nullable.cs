using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp5
{
   public class Nullable<T> where T:struct 
    {
        public Nullable(T value)
        {
            _hasValue = true;
            _value = value;
        }

        private bool _hasValue;
        public bool HasValue => _hasValue;

        private T _value;

        public T Value
        {
            get
            {
                if (!_hasValue)
                {
                    throw new InvalidOperationException("no value");
                }
                return _value;
            }
        }

        public static explicit operator T(Nullable<T> value) => value.Value;

        public static implicit operator Nullable<T>(T value)=>new Nullable<T>(value);

        public override string ToString()=>!HasValue?string.Empty:_value.ToString();

    }
}
