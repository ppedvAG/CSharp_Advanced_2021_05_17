using System;
using System.Reflection;

namespace HelloReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dll wird in Speicher geladen
            Assembly geladeneDll = Assembly.LoadFrom("TrumpTaschenrechner.dll");

            Type trumpTaschnrechnerTyp = geladeneDll.GetType("TrumpTaschenrechner.Taschenrechner");

            object tr = Activator.CreateInstance(trumpTaschnrechnerTyp);

            MethodInfo addInfo = trumpTaschnrechnerTyp.GetMethod("Add", new Type[] { typeof(Int32), typeof(Int32) });

            var result = addInfo.Invoke(tr, new object[] { 33, 11 });

            Console.WriteLine(result);
            Console.ReadLine();


        }
    }
}
