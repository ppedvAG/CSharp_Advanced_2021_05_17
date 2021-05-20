using System;
using System.Collections;
using System.Collections.Generic;

using System.Linq;

namespace GenericBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<string> strLis = new List<string>();
            
            
            IDictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary.Add(1, "Hallo liebe Teilnehmer");
            dictionary.Add(2, "C# macht Spass!");

            KeyValuePair<int, string> entry = new KeyValuePair<int, string>(3, "1234567 Lottozahlen");
            dictionary.Add(entry);

            if (!dictionary.ContainsKey(2))
                dictionary.Add(2, "Hallo liebe Teilnehmer");

            foreach (KeyValuePair<int, string> currentEntry in dictionary)
            {
                Console.WriteLine($"{currentEntry.Key} {currentEntry.Value}");
            }

            //Index ist der definierte Key (int) -> IDictionary<int, ....>
            string value = dictionary[1];

            IDictionary<Guid, string> dictionary1 = new Dictionary<Guid, string>();
            
            Hashtable hashTable = new Hashtable();
            hashTable.Add(1, "abc");
            hashTable.Add(1, "abc");
            hashTable.Add("abc", 1);
            hashTable.Add(DateTime.Now, "def");


            DataStore<Guid> store = new DataStore<Guid>();

            store.AddOrUpdate(1, Guid.NewGuid());
            store.DisplayDefault<DateTime>();
        }

        

    }


    public class DataStore<T>
    {
        private T[] _data = new T[10];

        public T[]Data
        {
            get => _data;
            set => _data = value;
        }

        public void AddOrUpdate(int index, T item)
        {
            if (index >= 0 && index < 10)
                _data[index] = item;
        }

        public T GetData(int index)
        {
            if (index >= 0 && index < 10)
                return _data[index];
            else
                return default(T);
        }


        public void DisplayDefault<ABC>()
        {
            ABC item = default(ABC);

            Console.WriteLine($"Default value of {typeof(ABC)} is {(item == null ? "null" : item.ToString())}.");
        }
    }
}
