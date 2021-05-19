using System;
using System.Threading;

namespace MonitorSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static void KritischerCodeAbschnitt()
        {
            int x = 1;

            DayOfWeek dayOfweek = DateTime.Now.DayOfWeek;
            Monitor.Enter(x);

            if (dayOfweek == DayOfWeek.Monday)
                Monitor.Exit(x);
        }
    }
}
