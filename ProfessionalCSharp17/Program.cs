using System;

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

        static void UseReadonlyRefMember()
        {
            Console.WriteLine(nameof(UseReadonlyRefMember));
            var d = new Data(11);
            int n = d.GetReadonlyNumber();
            n = 42;
            d.Show();

            ref readonly int n2 = ref d.GetReadonlyNumber();
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
        private static void SpanOnTheHeap()
        {
            Console.WriteLine(nameof(SpanOnTheHeap));
            Span<int> span1 = (new int[] { 1, 5, 11, 71, 22, 19, 21, 33 }).AsSpan();
            span1.Slice(start: 4, length: 3).Fill(42);
            Console.WriteLine(string.Join(",",span1.ToArray()));
            Console.WriteLine();
        }

        private static unsafe void SpanOnTheStack()
        {
            Console.WriteLine(nameof(SpanOnTheStack));
            long* lp = stackalloc long[20];
            var span1 = new Span<long>(lp,20);
            for (int i = 0; i < 20; i++)
            {
                span1[i] = i;
            }
            Console.WriteLine(string.Join(",",span1.ToArray()));
            Console.WriteLine();
        }
    }
}
