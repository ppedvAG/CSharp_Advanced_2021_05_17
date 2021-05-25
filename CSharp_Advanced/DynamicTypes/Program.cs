using System;
using System.Dynamic;

namespace DynamicTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic myObj = new ExpandoObject();

            myObj.Vorname = "Max";
            myObj.Nachname = "Mustermann";
            myObj.Geb = new DateTime(2001, 3, 3);

            Console.WriteLine($"{myObj.Vorname} {myObj.Nachname} {myObj.Geb}");

            



        }
    }
}
