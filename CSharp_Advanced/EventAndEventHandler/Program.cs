using System;

namespace EventAndEventHandler
{

   

    class Program
    {
        static void Main(string[] args)
        {
            ProcessBusinessLogic pbl = new ProcessBusinessLogic();
            pbl.ProcessInWorking += Pbl_ProcessInWorking;
            pbl.ProcessCompled += Pbl_ProcessCompled;
            pbl.StartProcess();
        }

        private static void Pbl_ProcessCompled()
        {
            Console.WriteLine("EventAndEventHandler.Programm: Bin fertig");
        }

        private static void Pbl_ProcessInWorking(int processBarValue)
        {
            Console.WriteLine("EventAndEventHandler.Programm: " + processBarValue);
        }
    }
}
