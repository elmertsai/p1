using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using PizzaWorld.Domain.Models;

namespace PizzaWorld.Domain.Singletons
{
    public class ClientSingleton
    {
        private static ClientSingleton _instance;
        public List<Store> Stores {get;set;}
        public List<Pizza> Pizzas { get; set; }

        private const string _path  = @"PizzaWorld.xml";

        public static ClientSingleton Instance 
        {
            get
            {
                if(Instance1 == null)
                {
                    Instance1 = new ClientSingleton();
                }
                return Instance1;
            }
        }

        public static ClientSingleton Instance1 { get => _instance; set => _instance = value; }

        private ClientSingleton()
        {
            Read();
        }
        public void GetAllStores()
        {

        }

        public void MakeAStore()
        {
            Stores.Add(new Store());
            Save();
        }
        public void MakeAPizza()
        {
            
        }
        public Store SelectStore()
        {
            bool done = false;
            var input = 0;
            while(!done)
            {
                int.TryParse(Console.ReadLine(), out input);

                if(input > Stores.Count|| input <=0)
                {
                    Console.WriteLine("Please enter a valid input (Number representing the store)");
                }
                else
                {
                    Console.WriteLine("Selecting store...");
                    done = true;
                }
                 
            }

            return Stores.ElementAtOrDefault(input-1); // null if there's error

        }
        public int UserOrStore() //return 1 if user, 2 if store
        {
            bool done = false;
            var input = 0;
            Console.WriteLine("Select to use as user or store:");
            Console.WriteLine("1) User");
            Console.WriteLine("2) Store");
            while(!done)
            {
                int.TryParse(Console.ReadLine(), out input);

                if(input == 1)
                {
                    Console.WriteLine("Using the app as user...");
                    return 1;
                }
                else if(input ==2)
                {
                    Console.WriteLine("Using the app as store...");
                    return 2;
                }
                else
                {
                    Console.WriteLine("Please enter a valid option");
                }
     
                 
            }
            return -1; //should not reach here
        }

        private void Save()
        {
            var file = new StreamWriter(_path);
            var xml = new XmlSerializer(typeof(List<Store>)); 

            xml.Serialize(file, Stores);
        }
        private void Read()
        {
      if (!File.Exists(_path))
      {
        Stores = new List<Store>();
        return;
      }

      var file = new StreamReader(_path);
      var xml = new XmlSerializer(typeof(List<Store>));

      Stores = xml.Deserialize(file) as List<Store>;
            
        }

    }
}