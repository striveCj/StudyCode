using System;

namespace ProfessionalCSharp17
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
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
