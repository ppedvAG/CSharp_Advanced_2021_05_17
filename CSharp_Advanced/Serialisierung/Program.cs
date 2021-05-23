using Newtonsoft.Json;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Xml.Serialization;

using Serialisierung.Extentions;

namespace Serialisierung
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person
            {
                Vorname = "Max",
                Nachname = "Mustermann",
                Alter = 64,
                Kontostand = 100_000,
                Kreditlimit = 500_000
            };
            Stream stream = null;
            #region Binären Serialisierung



            BinaryFormatter binaryFormatter = new BinaryFormatter();
            stream = File.OpenWrite("Person.bin");
            binaryFormatter.Serialize(stream, person);
            stream.Close();
            #endregion

            #region Binäre Datei lesen

            stream = File.OpenRead("Person.bin");
            Person geladenePerson = (Person)binaryFormatter.Deserialize(stream);
            stream.Close();


            #endregion

            #region XML schreiben
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
            stream = File.OpenWrite("Person.xml");
            xmlSerializer.Serialize(stream, person);
            stream.Close();
            #endregion

            #region XML lesen
            stream = File.OpenRead("Person.xml");
            Person geladenePerson1 = (Person)xmlSerializer.Deserialize(stream);
            #endregion

            string jsonString = JsonConvert.SerializeObject(person);
            Task task = File.WriteAllTextAsync("Person.json", jsonString);
            task.Wait();


            //jsonStrin = File.ReadAllText
            Person jsonPerson = JsonConvert.DeserializeObject<Person>(jsonString);

            //variable person wird in Erweiterungsmethode als -> this person p verwendet. 
            person.Serialize("Person.csv");

            Person geladenePerson2 = new Person();
            geladenePerson2.Deserialize("Person.csv");
        }
    }

    [Serializable]
    public class Person
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public int Alter { get; set; }

        [field: NonSerialized] // gelten bei Binary und JSON
        public decimal Kontostand { get; set; }
        
        
        [NonSerialized()]// gelten bei Binary und JSON
        public decimal Kreditlimit;
    }
}
