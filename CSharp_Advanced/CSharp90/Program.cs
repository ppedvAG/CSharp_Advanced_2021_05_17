using System;

namespace CSharp90
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal tier1 = new Animal() { Id = 1, Name = "Katze" };
            Animal tier2 = new Animal() { Id = 1, Name = "Katze" };



            Person person1 = new Person(1, "Hannes", "Preishuber");
            Person person2 = new Person(1, "Hannes", "Preishuber");

            PersonV2 pv1 = new PersonV2("Max", "Mustermann");

            PersonV2 personPV1_Clon = pv1 with { LastName = "Musterfrau" };
            //personPV1_Clon.FirstName - Max
            //personPV1_Clon.LastName - Musterfrau


            if (tier1 == tier2)
            {
                Console.WriteLine("Tier-Objekte sind gleich");
            }
            else
            {
                Console.WriteLine("Tier-Objekte sind ungleich");
            }


            if (person1 == person2)
            {
                Console.WriteLine("Person-Objekte sind gleich");
            }
            else
            {
                Console.WriteLine("Person-Objekte sind ungleich");
            }

            Console.ReadKey();
        }
    }

    public record Person (int Id, string Vornamen, string Nachnamen);

    public record PersonV2
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }

        private PersonV2()
        {

        }

        public PersonV2 (string firstname, string lastname)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
        }

        public void Init()
        {
             //Mach was 
        }
    };

    public record Employee(int Versicherungsnummer, DateTime AngestelltSeit, int Id, string Vornamen, string Nachnamen) 
        : Person(Id, Vornamen, Nachnamen);




    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
