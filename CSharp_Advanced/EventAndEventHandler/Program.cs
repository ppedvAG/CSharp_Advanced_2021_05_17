using System;
using System.Collections.Generic;

namespace EventAndEventHandler
{

   

    class Program
    {
        static IDictionary<int, string> _dict = new Dictionary<int, string>();
        
        static void Main(string[] args)
        {
            ProcessBusinessLogicComponent pbl = new ProcessBusinessLogicComponent();
            pbl.ProcessInWorking += Pbl_ProcessInWorking;
            pbl.ProcessCompled += Pbl_ProcessCompled;
            pbl.StartProcess();


            ProcessBusinessLogicComponent2 pblc2 = new ProcessBusinessLogicComponent2();
            pblc2.ProcessCompleted += Pblc2_ProcessCompleted;
            pblc2.ProcessCompletedNew += Pblc2_ProcessCompletedNew;
            pblc2.Start();
        }

        private static void Pblc2_ProcessCompletedNew(object sender, EventArgs e)
        {
            if (e is not MyEventArg)
                return; //Exception ist auch gut. 


            MyEventArg myEventArg = (MyEventArg)e;

            Console.WriteLine($"Bin fertig {myEventArg.Uhrzeit.ToString()}");
        }

        private static void Pblc2_ProcessCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Bin Fertig!");
        }

        private static void Pbl_ProcessCompled()
        {
            Console.WriteLine("EventAndEventHandler.Programm: Bin fertig");
        }

        private static void Pbl_ProcessInWorking(int processBarValue)
        {
            Console.WriteLine("EventAndEventHandler.Programm: " + processBarValue);

            _dict.Add(processBarValue, "Test");
        }

        public void test()
        {

        }
    }
}
