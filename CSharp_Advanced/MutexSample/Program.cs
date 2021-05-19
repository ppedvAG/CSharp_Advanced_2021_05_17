using System;
using System.Threading;

namespace MutexSample
{
    class Program
    {
        private static Mutex mutex = null;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static void DoSomething()
        {
            mutex = new Mutex(false, "MyMutex");

            bool lockToken = false;

            try
            {

                lockToken = mutex.WaitOne();
            }
            finally
            {
                if (lockToken)
                    mutex.ReleaseMutex();

            }
           
        }
    }
}
