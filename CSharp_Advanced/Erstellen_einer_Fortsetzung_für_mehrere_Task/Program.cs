using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Erstellen_einer_Fortsetzung_für_mehrere_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<Task<int>> tasks = new List<Task<int>>();


            for (int i = 1; i <= 10; i++)
            {
                int baseValue = i;
                tasks.Add(Task.Factory.StartNew(b => (int)b * (int)b, baseValue));
            }

            Task<int[]> results = Task.WhenAll(tasks); //WhenAll wartet auf das Ergebnis einer IEnumerable Task und gibt auch ein Array als Ergebnis zurück

            int sum = 0;

            for (int y = 0; y <= results.Result.Length - 1; y++)
            {
                var result = results.Result[y];

                Console.Write($"{result} {((y == results.Result.Length - 1) ? "=" : "+")} ");
                sum += result;
            }

            Console.WriteLine(sum);
            // The example displays the similar output:
            //    1 + 4 + 9 + 16 + 25 + 36 + 49 + 64 + 81 + 100 = 385


            Console.ReadKey();
        }
    }
}
