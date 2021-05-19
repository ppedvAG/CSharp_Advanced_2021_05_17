using System;
using System.Threading;

namespace MutexSample_ProgrammInstance
{
    class Program
    {
        static Mutex _mutex;

        static void Main(string[] args)
        {
            if (!Program.IsSingleInstance())
            {
                Console.WriteLine("More than one instance");
            }
            else
                Console.WriteLine("one Instance");

            Console.ReadKey();
        }

        static bool IsSingleInstance()
        {
            try
            {
                // Mutex.TryOpenExisting wäre bessere alternative
                //Zweite Programm-Instance kann diese Zeile ohne Fehler ausführen
                Mutex.OpenExisting("ABC");
            }
            catch
            {
                //Beim ersten Start wird diese Zeile ausgeführt
                Program._mutex = new Mutex(true, "ABC");
                return true;
            }

            return false;
        }
    }
}
