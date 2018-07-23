using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsBook_Csharp.SingletonPattern
{
    class Singleton
    {
        private static Singleton instance;
        private static readonly object syncRoot = new object();
        private Singleton()
        {

        }
        public static Singleton GetInstance()
        {
            if (instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }

        public static Singleton GetInstance2()
        {
            lock (syncRoot)
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
            }
            return instance;
        }
        public static Singleton GetInstance3()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                }
            }
           
            return instance;
        }

    }
}
