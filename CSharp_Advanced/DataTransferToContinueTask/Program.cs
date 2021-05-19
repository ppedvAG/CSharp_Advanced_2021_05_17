using System;
using System.Threading.Tasks;

namespace DataTransferToContinueTask
{
    class Program
    {
        public static async Task Main() =>
            await Task.Run(
               () =>
               {
                   DateTime date = DateTime.Now;
                   return date.Hour > 17
                      ? "evening"
                      : date.Hour > 12
                          ? "afternoon"
                          : "morning";
               })
               .ContinueWith(
                   antecedent =>
                   {
                       if (antecedent.Status == TaskStatus.RanToCompletion)
                       {
                           Console.WriteLine($"Good {antecedent.Result}!");
                           Console.WriteLine($"And how are you this fine {antecedent.Result}?");
                       }
                       else if (antecedent.Status == TaskStatus.Faulted)
                       {
                           Console.WriteLine(antecedent.Exception.GetBaseException().Message);
                       }
                   });

        static async Task Main1(string[] args)
        {
            Task<string> task = Task.Run( //Aufruf einer anonymen Methode
           (/*Parameterliste*/) =>
           {
               DateTime date = DateTime.Now;
               return date.Hour > 17
                  ? "evening"
                  : date.Hour > 12
                      ? "afternoon"
                      : "morning";
           });

            await task.ContinueWith(
                antecedent =>
                {
                    //Console.WriteLine($"Good {antecedent.Result}!");
                    //Console.WriteLine($"And how are you this fine {antecedent.Result}?");
                }, TaskContinuationOptions.OnlyOnRanToCompletion);
            Console.ReadKey();
        }





        public static string DayTimeCheck()
        {
            DateTime date = DateTime.Now;
            return date.Hour > 17
               ? "evening"
               : date.Hour > 12
                   ? "afternoon"
                   : "morning";
        }
    }
}
