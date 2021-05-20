using System;
using System.Threading;
using System.Linq;

namespace ThreadWithReturnValue
{
    class Program
    {
        static void Main(string[] args)
        {
            string retStr = string.Empty;
            Thread thread = new Thread(() => { retStr = MyFunction("Hello World") });
            thread.Start();
            thread.Join();
        }

        
 
        public static string MyFunction(string param1) 
        {
            return param1.ToUpper();
        }

    }
}
