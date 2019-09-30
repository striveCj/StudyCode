using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp6
{
    public class Currency
    {
        public uint Dollars { get; }
        public  ushort Cents { get; }

        public Currency(uint dollars, ushort cents)
        {
            Dollars = dollars;
            Cents = cents;
        }

        public override string ToString() => $"${Dollars}.{Cents,-2:00}";

        public static implicit operator float(Currency value) => value.Dollars + (value.Cents / 100.0f);

        public static explicit operator Currency(float value)
        {
            uint dollars = (uint) value;
            ushort cents = (ushort) ((value - dollars) * 100);
            return new Currency(dollars, cents);
        }1
    }
}
