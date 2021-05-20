using System;
using System.Threading.Tasks;

namespace _003_TaskWithParameter
{
    class Program
    {
        static void Main(string[] args)
        {
            Katze katze = new();

            //Task meinTask //MachEtwas müsste void zurück geben
            try
            { 

            }
            catch (AggregateException ex) //AggregateException Threads / Task 
            {
                foreach (Exception innerException in ex.InnerExceptions)
                { 
                    //Loge jeden Fehler nacheinander 
                }
            }


            //Task<string> -> string Returnwert
            Task<string> easyTask = new Task<string>(() => MachEtwas(katze, DateTime.Now));
            easyTask.Wait();
            string result = easyTask.Result;

            Task<string> task1 = Task.Factory.StartNew(MachEtwas, katze);
            task1.Wait();
            string result1 = task1.Result;

            Task<string> task2 = Task.Run<string>(() => MachEtwas(katze));


        }

        private static string MachEtwas(object input)
        {
            Katze katze = null;

            if (input is Katze)
                katze = (Katze)input;

            return DateTime.Now.ToLongDateString();
        }


        private static string MachEtwas(object input, DateTime date)
        {
            Katze katze = null;

            if (input is Katze)
                katze = (Katze)input;

            return DateTime.Now.ToLongDateString();
        }
    }

    

    public class Katze
    {
        public string Name { get; set; } = "Maya";
    }
}
