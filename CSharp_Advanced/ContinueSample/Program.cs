using System;
using System.Threading;
using System.Threading.Tasks;

namespace ContinueSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t1 = new Task(() =>
            {
                Console.WriteLine("Task 1 ist gestartet");
                Thread.Sleep(800);
                throw new Exception();
            });

            t1.Start();
            t1.ContinueWith(t => { Console.WriteLine("T1 Continue"); });
            t1.ContinueWith(t => { Console.WriteLine("T1 ist ok"); }, TaskContinuationOptions.OnlyOnRanToCompletion);
            t1.ContinueWith(t => { Console.WriteLine("T1 hat ein Fehler"); }, TaskContinuationOptions.OnlyOnFaulted);

            Console.ReadLine();
        }
    }
}
