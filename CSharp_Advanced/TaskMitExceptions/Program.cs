using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskMitExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t1 = null, t2 = null, t3 = null, t4 = null;

            try
            {
                t1 = new Task(MachEinenFehler1);
                t1.Start();

                t2 = Task.Factory.StartNew(MachEinenFehler2);

                t3 = Task.Run(MachEinenFehler3);
                t4 = Task.Run(MachKeinenFehler);

                Task.WaitAll(t1, t2, t3, t4); //<- Hier wird die Fehlermeldung an die 'UI' Thread übergeben
            }
            catch (AggregateException ex)
            {
                foreach (var einzelneException in ex.InnerExceptions)
                {
                    Console.WriteLine(einzelneException.Message);
                }
            }


            if (t4.IsCompleted)
            {
                Console.WriteLine("Task ist fertig");
            }

            if (t3.IsFaulted)
            {
                Console.WriteLine("Task 3 hat einen Fehler");
            }

            if (t3.IsCanceled)
                Console.WriteLine("Task 3 wurde abgebrochen");



            Console.ReadLine();
        }


        private static void MachEinenFehler1()
        {
            Thread.Sleep(3000);
            throw new DivideByZeroException();
        }

        private static void MachEinenFehler2()
        {
            Thread.Sleep(3000);
            throw new StackOverflowException();
        }

        private static void MachEinenFehler3()
        {
            Thread.Sleep(3000);
            throw new OutOfMemoryException();
        }

        private static void MachKeinenFehler()
        {
            Console.WriteLine("Methode ohne Fehler");
        }
    }
}
