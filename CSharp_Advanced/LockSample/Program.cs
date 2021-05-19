using System;
using System.Threading;

namespace LockSample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                #region Lock-Sample
                for (int i = 0; i < 10; i++)
                    ThreadPool.QueueUserWorkItem(Mach500KontoUpdates);

                Console.WriteLine("fertig");
                Console.ReadKey();
                #endregion
            }
            catch (AggregateException ex)
            {

            }
            catch(Exception ex)
            {

            }

            
        }


        private static void Mach500KontoUpdates(object state)
        {
            Random r = new Random();

            Konto meinKonto = new Konto();

            for (int i = 0; i< 500; i++)
            {
                int auswahl = r.Next(0, 10);

                if (auswahl %2 ==0)
                {
                   
                    meinKonto.Einzahlen(r.Next(1, 1000));
                }
                else
                    meinKonto.Abheben(r.Next(1, 1000));


                Console.WriteLine(meinKonto.Kontostand);
            }
        }

    }
}
