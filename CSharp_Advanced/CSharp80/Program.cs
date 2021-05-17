using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharp80
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<string> strList = new List<string>();

            //strList[] ->Index


            string str = "Hello World";

           string oputput =  str[..];


            string escapeFeatures = "HAllo Welter \n Ich schreibe \t in einer neuen Zeile";

            string filePath = @"C:\Windows\Temp\log.txt";


            Console.WriteLine("{0} {1}", str , oputput);
            Console.WriteLine($"{filePath} statische Texte kann man auch noch ausgeben\t {str}");


            ICar car = new Car();
            car.Init(); //Defaultimplementierung

            Car car1 = new Car(); // Interface Default-Impplementierungen sind nicht dabei
            ICar convertedCar = (ICar)car1;
            convertedCar.Init();
        }

        //Listen die gestream werden (z.b grpc), verwenden die yield return + 
        public static async IAsyncEnumerable<int> GeneriereZahlen()
        {
            for (int i = 0; i < 20; i++)
            {
                await Task.Delay(100);

                yield return i; // <- 
            }
        }

        public static async void GebeZahlAus()
        {
            //var Zahl = 0,1,2,3,4,5,6,7,8,
            await foreach (var zahl in GeneriereZahlen())
            { 
                Console.WriteLine(zahl);  //0,1,2,3,4,5,6,7,8,
            }
        }


        public interface ICar
        {
            string Modell { get; set; } //wird in der Implementierten Klasse als public dargestellt 

            public void Init ()
            {
                System.Console.WriteLine("Eine Default Implementierung");
            }

            void Init5();
            abstract void Init2(); // -> Zielt nicht auf eine Klassenimplementierung -> Feature wird bei Vererbung von Interfaces verwenden 
            
            virtual void Init4() //-> Default Implementierung
            {
                //Default Implemtieren 
            }

            
        }

        public interface ISubCar : ICar
        {
            
        }



        public class Car : ICar
        {
            public string Modell { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


            //abstract void Init2();
            public void Init2()
            {
                throw new NotImplementedException();
            }

            //void Init5();
            public void Init5()
            {
                throw new NotImplementedException();
            }

            public void Init3()
            {
                throw new NotImplementedException();
            }
        }

    }
}
