using System;

namespace CSharp72
{
    class Program
    {
        static void Main(string[] args)
        {
            Summe(124);
            Summe(123, 232);
            Summe(12, 24, 36);

            OptionaleParam(1);
            OptionaleParam(1, 2);

        }

        public static void OptionaleParam(int a = 1, int b = 2)
        {

        }

        public static long Summe(int zahl1, int zahl2 = default, int zahl3 = default)
        {
            return zahl1 + zahl2 + zahl3;
        }
    }
}
