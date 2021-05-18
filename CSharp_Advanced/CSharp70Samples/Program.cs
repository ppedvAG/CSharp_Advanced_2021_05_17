using System;

namespace CSharp70Samples
{
    class Program
    {
        //Was ist Was? 
        int werBinIchA;
        string string1;
        char zeichen = 'X';

        
        
        //Interne 
        String string2;
        Int32 WerBinIchB;

        static void Main(string[] args)
        {
            #region Out-Variablen
            string inputToConvert = "12345a";
            int number=11; //Default-Wert
            
            //out - Regel: Wenn eine Methode in seiner Parameter "out" verwendet, muss diese Variable innerhalb der Methode eine Zuweisung erfahren.
            if (int.TryParse(inputToConvert, out number))
            {
                //Wenn hier bin, weiß ich, dass number eine initialisierte Zahl darstellt 
                //number =12345

                Console.WriteLine($"Converted Number: {number}");
            }
            else
            {
                //Bei der Konventierung ist etwas schief gelaufen. 
            }
            #endregion


            Person p = new Person("Max", "Maxi", "Mustermann");

            #region Tupel
            //Tupel Beispiel 1: 
            //var name = p.VollenNamenAusgabe();

            //Console.WriteLine(name.Item1); //Vorname
            //Console.WriteLine(name.Item2); //Zweiter Vorname
            //Console.WriteLine(name.Item3); //Nachname



            //Tupel Beispiel 2: 
            //var name = p.VollenNamenAusgabe();

            //name.Vorname 
            //name.ZweiterVorname
            //name.Nachname

            string vornamen, nachnamen;
            (vornamen,_,nachnamen) = p.VollenNamenAusgabe(); ;
            #endregion


            #region Literale und Variablen

            int eineMillionen = 1_000_000;

            decimal myMoney = 123123123.343m;





            #endregion
        }
    }

    class Person
    {
        public string Firstname { get; set; }
        public string SecondFirstname { get; set; }
        public string Lastname { get; set; }

        //ctor + tab + tab
        public Person(string firstName,  string secondName, string lastName)
        {
            this.Firstname = firstName;
            this.Lastname = lastName;
            this.SecondFirstname = secondName;
        }


        //public (string, string ,string) VollenNamenAusgabe()
        //{
        //    return (Firstname, !string.IsNullOrEmpty(SecondFirstname) ? SecondFirstname : string.Empty, Lastname);
        //}
        public (string Vorname, string ZweiterVorname, string Nachname) VollenNamenAusgabe()
        {
            return (Firstname, !string.IsNullOrEmpty(SecondFirstname) ? SecondFirstname : string.Empty, Lastname);
        }




    }





}
