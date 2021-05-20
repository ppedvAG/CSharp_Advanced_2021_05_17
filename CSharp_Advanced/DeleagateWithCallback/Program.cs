using System;

namespace DeleagateWithCallback
{
    class Program
    {
        public delegate void Del(string message);


        static void Main(string[] args)
        {
            Del handler = new Del(DelegateMthod);

            MethodWithCallback(12, 33, handler);

        }


        public static void MethodWithCallback(int param1, int param2, Del callback)
        {
            //Ganz viel Logik wird berechnet....





            callback("Methode ist erfolgreich durchgelaufen"); // -> Gehe danach auf -> public static void DelegateMthod(string message)
        }


        //Wird aufgerufen, wenn ich mit irgendwas fertig bin -> Erfolgs- oder Fehlermeldungmeldung.
        public static void DelegateMthod(string message)
        {
            Console.WriteLine(message);
        }
    }
}
