﻿using System;

namespace ProfessionalCSharp17
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public class Data
        {
            public Data(int anumber) => _anumber = anumber;

            private int _anumber;

            public ref int GetNumber() => ref _anumber;

            public ref readonly int GetReadonlyNumber() => ref _anumber;

            public void Show() => Console.WriteLine($"Data:{_anumber}");
        }

        static void UseMember()
        {
            Console.WriteLine(nameof(UseMember));
            var d = new Data(11);
            int n = d.GetNumber();
            n = 42;
            d.Show();
            Console.WriteLine();
        }

        static void UseRefMember()
        {
            Console.WriteLine(nameof(UseRefMember));

            var d = new Data(11);

            ref int n = ref d.GetNumber();
            n = 42;
            d.Show();
            Console.WriteLine();
        }


        public class ResourceHolder : IDisposable
        {
            private bool _isDisposed = false;
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            protected virtual void Dispose(bool disposing)
            {
                if (!_isDisposed)
                {
                    if (disposing)
                    {

                    }
                }
                _isDisposed = true;
            }
            ~ResourceHolder()
            {
                Dispose(false);
            }

            public void SomeMethod()
            {
                if (_isDisposed)
                {
                    throw new ObjectDisposedException("ResourceHolder"); 
                }
            }
        }
        
    }
}
