using System;

namespace LizkovSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    interface IAnimal
    {
        string MakeNoise();
    }

    public class Dog : IAnimal
    {
        public string MakeNoise()
        {
            //Hund isst 
            // Hund krazt sich
            return "wuff wuff";
        }
    }

    public class Cat : IAnimal
    {
        public string MakeNoise()
        {
            return "meow";
        }
    }

}
