using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp80
{
    public interface IAnimal
    {
        public void MakeNoise()
        {
            Console.WriteLine("Animal make Noise");
        }

        public virtual void Sleep()
        {
            Console.WriteLine("Animal Sleep");
        }    
    }

    public interface IDog : IAnimal
    {
        void IAnimal.Sleep()
        {
            Console.WriteLine("Dog Sleep");
        }

        abstract void IAnimal.MakeNoise();
    }

    public interface ICat : IAnimal
    {

        abstract void IAnimal.MakeNoise();
    }

    public class Cat : ICat
    {
        public void MakeNoise()
        {
            Console.WriteLine("meow meow");
        }
    }

    public class Dog : IDog
    {
        public void MakeNoise()
        {
            Console.WriteLine("wuff wuff");
        }
    }


}
