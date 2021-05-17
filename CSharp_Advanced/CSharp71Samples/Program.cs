using System;

namespace CSharp71Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            int zahl = 11;
            string name = "Tester";


            var tupel = (zahl, name);


            int i = default;


            //du hast keinen Wert
            int? nullableValue = 1234;

            //geht ist aber nicht best pratice
            //int? abc = nullableValue.Value;

            if (nullableValue.HasValue)
            {
                //gibt es einen Integer-Wert in nullableValue? 

                //Hier gibt es einen

                Console.WriteLine(nullableValue.Value);
            }






            if (i == 0) //Was ist "0"....normaler Wert, Initial-Wert
            {

            }
            
            if (i is default(int)) // hat den default-wert
                Console.WriteLine("Test");

            string leereString = string.Empty;
            if (string.IsNullOrEmpty(leereString))
            {
                //Wenn leereString einen Wert hätte, könnte ich diesen Block hier ausführen 
            }
            DisplayDefaultOf<string>();
            DisplayDefaultOf<DateTime>();


            int myZahl = 10;
            Test(ref myZahl);

            // tupel.name;
            // tupel.zahl;
        }


        static void DisplayDefaultOf<T>()
        {
            var val = default(T);
            Console.WriteLine($"Default value of {typeof(T)} is {(val == null ? "null" : val.ToString())}.");
        }

        public static void Test(ref int zahl)
        {
            zahl = 123;

            ref int x = ref zahl; //Wertezuweisung 
            x++;
        }

    }
}
