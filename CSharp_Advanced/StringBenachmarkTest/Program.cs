using System;
using System.Diagnostics;
using System.Text;

namespace StringBenachmarkTest
{
    class Program
    {
        static void Main(string[] args)
        {

            //string myString = "Hallo"; // reserviert einen Speicher von 5 Zeichen

            //myString += "weiter Text"; // 1.)  16 Zeichen werden reserviert  2.) vorhande 5 Zeichen werden in neue Kopiert 3.) die anderen 11 Zeichen werden in die Adresse übertrage 
            //myString += "Hallo liebe Teilnehmer";

            string aufbauenString = string.Empty;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < 100000; i++)
            {
                aufbauenString += i.ToString();


                // string str = "12345";
                
                // str+="6789" -> str = "123456789"

                //reserviert im Speicher ein String mit 9-Zeichen
                //Reserviert neuen Arbeitsspeicher mit der neuen größe

                //Kopiert 1,2,3,4,5 rüber 
                //Kopiert vorhanden String von alter Speicheradresse in die Neue

                // 6,7,8,9 wird hinzugefügt
                //Fügt er den neuen String dem älteren hinzu
            }
            stopwatch.Stop();
            long testErgebnis1 = stopwatch.ElapsedMilliseconds;

            Console.WriteLine("###### Press Key ########");
            Console.ReadKey();

            StringBuilder sb = new StringBuilder();

            Stopwatch watch1 = new Stopwatch();
            watch1.Start();

            for(int i = 0; i< 100000; i++)
            {
                sb.Append(i.ToString());
            }

            string putput = sb.ToString(); //hier wird der String einmalig zusammen gesetzt. 
            watch1.Stop();
            long testErgebnis2 = watch1.ElapsedMilliseconds;
            Console.WriteLine("Benchmark Ergebnis: ");
            Console.WriteLine($"Ergebis mit + - Operator: {testErgebnis1}");
            Console.WriteLine($"Ergebis mit StringBuilder : {testErgebnis2}");

            Console.ReadLine();
        }
    }
}
