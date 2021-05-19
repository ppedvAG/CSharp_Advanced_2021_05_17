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

            Task<string> easyTask = new Task<string>(() => MachEtwas(katze, DateTime.Now));
            easyTask.Wait();

            Task<string> task1 = Task.Factory.StartNew(MachEtwas, katze);
            task1.Wait();
            string result = task1.Result;

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
