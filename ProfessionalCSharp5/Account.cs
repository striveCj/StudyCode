using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp5
{
    public interface IAccount
    {
        decimal Balance
        {
            get; 
            
        }
        string Name { get; }
    }
    public class Account:IAccount
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

        public static decimal Accumulate<TAccount>(IEnumerable<TAccount> source) where TAccount : IAccount
        {
            decimal sum = 0;
            foreach (var a in source)
            {
                sum += a.Balance;
            }
            return sum;
        }

        
    }

    public class MethodOverloads
    {
        public void Foo<T>(T obj) => Console.WriteLine($"{obj.GetType().Name}");
        public void Foo<T>(int x) => Console.WriteLine($"foo int x");
        public void Foo<T1,T2>(T1 obj,T2 obj2) => Console.WriteLine($"{obj.GetType().Name}");
        public void Foo<T>(int onj1 ,T obj) => Console.WriteLine($"{obj.GetType().Name}");
        public void Bat<T>(T obj) =>Foo(obj);
    }
    
}
