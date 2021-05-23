using System;

namespace DeleagateWithCallback
{
    class Program
    {
        public delegate void Del(string message);


        static void Main(string[] args)
        {
            Del handler = new Del(ShowResult);

            ProcessWithCallback(12, 33, handler);

        }


        public static void ProcessWithCallback(int param1, int param2, Del callback) //<- callback (Funktionszeiger -> ShowResult)
        {
            //Ganz viel Logik wird berechnet....


            //In der letzten Zeile der Methode (Wenn Logik abgearbeitet wurde) 
            callback("Methode ist erfolgreich durchgelaufen"); // -> Gehe danach auf -> public static void DelegateMthod(string message)
        }


        //Wird aufgerufen, wenn ich mit irgendwas fertig bin -> Erfolgs- oder Fehlermeldungmeldung.
        public static void ShowResult(string message)
        {
            Console.WriteLine(message);
        }
    }
}
