using System;

using System.Threading; 

namespace HelloThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            #region ThreadStart
            //Thread thread = new Thread(MachEtwas); //Funktionszeiger wird in Methode übergeben
            //thread.Start();

            //thread.Join(); //Warte bis der Thread(Methode: MachWas) fertig ist, bzw ein Ergebnis zurück
            
            //for (int i = 0; i <1000; i++)
            //    Console.Write("*");
            #endregion


            #region Thread Starten mit Parameter
            //ParameterizedThreadStart parameterizedThread = new ParameterizedThreadStart(MachEtwasMitParameter);

            //Thread thread1 = new Thread(parameterizedThread);
            //thread1.Start(20);
            //thread1.Join();
            
            //for (int i = 0; i < 1000; i++)
            //    Console.Write("*");
            #endregion


            #region Thread Beenden

            //Thread t = new Thread(MachEtwas1);
            //t.Start();
            //Thread.Sleep(2000);
            ////t.Abort();
            //t.Interrupt();
            //Console.WriteLine("Thread beenden");
            #endregion

            ThreadPool.QueueUserWorkItem(ZeichneRaute);
            ThreadPool.QueueUserWorkItem(ZeichnePunkt); //Methode benötigt ein object-Parameter 

            Console.ReadLine();
        }

        private static void MachEtwas()
        {
            try
            {
                for (int i = 0; i < 1000; i++ )
                {
                    Console.Write("#");
                }
            }
            catch (Exception ex)
            {
            }
        }


        private static void ZeichneRaute(object state)
        {
            try
            {
                for (int i = 0; i < 1000; i++)
                {
                    Console.Write("#");
                }
            }
            catch (Exception ex)
            {
            }
        }

        private static void ZeichnePunkt(object state)
        {
            try
            {
                for (int i = 0; i < 1000; i++)
                {
                    Console.Write(".");
                }
            }
            catch (Exception ex)
            {
            }
        }

        private static void MachEtwas1()
        {
            try
            {
                for (int i = 0; i < 1000; i++)
                {
                    Thread.Sleep(100);
                    Console.WriteLine("zZZzZZzzzZZ");
                }
            }
            catch (Exception ex)
            {
            }
        }

        private static void MachEtwasMitParameter(object obj)
        {
            try
            {
                for (int i = 0; i < (int)obj; i++)
                {
                    Console.Write("#");
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
