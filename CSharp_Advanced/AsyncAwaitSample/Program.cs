using System;
using System.Threading;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AsyncAwaitSample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Task task = Task.Run(SubMethode);
            task.Wait();

            await Task.Run(SubMethode);

        }

        public static async Task SubMethode()
        {
            //Normaler Task
            Task easyTask = Task.Run(MethodeOhneReturnwert);
            easyTask.Wait();


            await Task.Run(MethodeOhneReturnwert);


            //Mit Returnwerten
            Task<string> taskWithReturnValue = Task.Run(MethodeMitReturnwert);
            taskWithReturnValue.Wait(); //->ERgebniss liegt hier so vor -> taskWithReturnValue.Result
            string returnwert = taskWithReturnValue.Result;
            
            
            string retStr = await Task.Run(MethodeMitReturnwert);
        }

        public static void MethodeOhneReturnwert()
        {
            //Mach was
        }


        public static string MethodeMitReturnwert()
        {
            return DateTime.Now.ToString();
        }



        public static void DBConnection ()
        {
            string sqlString = "abc";
            SqlConnection sqlCon = new SqlConnection(sqlString);
            
            Task task = sqlCon.OpenAsync();
            task.Wait();
        }

        public static async Task DBConnectionWithAsyncAwait()
        {
            string sqlString = "abc";
            SqlConnection sqlCon = new SqlConnection(sqlString);
            await sqlCon.OpenAsync();

        }
    }
}
