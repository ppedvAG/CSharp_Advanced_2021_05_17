using System;
using System.Threading.Tasks; //ab .NET 4.0

namespace _001_EasyTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Task easyTask = new Task(MachEtwas);
            easyTask.Start(); //thread -> Start
            
            easyTask.Wait(); //thread -> Join

            for (int i = 0; i < 100; i++)
            {
                Console.Write("*");
            }
        }



        private static void MachEtwas()
        {
            try
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.Write("#");
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
