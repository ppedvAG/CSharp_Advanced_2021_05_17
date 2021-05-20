using System;

namespace DelegatesActionsFuncSample
{
    class Program
    {
        delegate int NumbChange(int num); //Dieses Delegate kann mit Methoden zusammenarbeiten (kapseln), die int-Return-Wert haben und einen int-Parameter. 
        delegate void NumbChange2(int a, int b, int c);

        static void Main(string[] args)
        {
            NumbChange nc1 = new NumbChange(Add12); //<-Übergeben Funktionszeiger
            
            int result = nc1(20); //Call Add12

            nc1 += Sub17;
            nc1(30);//Aufruf wird Add12 und danach Sub17 aufgerufen

            nc1 -= Add12;
            nc1(40); //Aufruf wird nur noch Sub17 aufgerufen
            Console.WriteLine($"{ result}");

            

            //Action mit Void-Methoden und keinem Parameter 
            Action a1 = new Action(VoidMethodeWithoutParams);
            a1(); //call VoidMethodeWithoutParams


            NumbChange2 nc2 = new NumbChange2(AddNums);
            nc2(20, 30, 44);

            Action<int, int, int> a2 = AddNums;
            a2 += AddNums; //Achtung AddNums wird 2x aufgerufen
            a2(22, 11, 44);

            Func<int, int, int> func1 = Addition;
            int result2 = func1(33, 33);





        }

        private static int Add12(int num)
        {
            return num + 12;
        }

        private static int Sub17(int num)
        {
            return num - 17;
        }

        private static void AddDefault()
        {
            return;
        }

        public static void VoidMethodeWithoutParams()
        {
            Console.WriteLine("Hello world!");
        }

        public static void AddNums(int a, int b, int c)
        {
            Console.WriteLine($"{ a + b + c}");
        }


        public static int Addition(int z1, int z2)
        {
            return z1 + z2;
        }
    }
}
