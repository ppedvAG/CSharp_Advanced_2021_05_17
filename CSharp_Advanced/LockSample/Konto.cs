using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockSample
{
    public class Konto
    {
        public decimal Kontostand { get; set; }
        
        //lock-flag
        public object lockObject = new object();

        public void Einzahlen(decimal betrag)
        {
            try
            {
                //zweiter Thread müsste hier warten, solange erster Thread noch im Lock-Block sich befindet
                lock (lockObject) //Thread kommt und belegt lock-Flog
                {
                    Console.WriteLine($"Kontostand vor dem Einzahlen: {Kontostand}");
                    Kontostand += betrag;
                    Console.WriteLine($"Kontostand nach dem Einzahlen: {Kontostand}");
                } //logFlag wird freigegeben
            }
            catch (Exception ex)
            {

            }
        }

        public void Abheben(decimal betrag)
        {
            try
            {
                //zweiter Thread müsste hier warten, solange erster Thread noch im Lock-Block sich befindet
                lock (lockObject) //Thread kommt und belegt lock-Flog
                {
                    Console.WriteLine($"Kontostand vor dem Abheben: {Kontostand}");
                    Kontostand -= betrag;
                    Console.WriteLine($"Kontostand nach dem Abheben: {Kontostand}");
                } //logFlag wird freigegeben
            }
            catch (Exception ex)
            {

            }
        }



    }
}
