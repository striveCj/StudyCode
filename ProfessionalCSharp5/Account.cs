using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp5
{
    public class Account
    {
        public string Name { get; }

        public decimal Balance { get; }

        public Account(string name,Decimal balance)
        {
            Name = name;
            Balance = balance;
        }
    }

    public static class Alogrithms
    {
        public static decimal AccumulateSimple(IEnumerable<Account> source)
        {
            decimal sum = 0;
            foreach (var a in source)
            {
                sum += a.Balance;
            }
            return sum;
        }
    }
}
