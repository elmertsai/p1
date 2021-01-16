using System.Collections.Generic;

namespace PizzaWorld.Client.Models
{
    public class StoreViewModel // Analogous to sqlclient we have in p0
    {
        public List<string> Stores { get; set; } //List<Store> when domain is connected 
        public List<string> Address{ get; set; }
        public StoreViewModel()
        {
            Stores = new List<string>()
            {
                "Store 1","Store 2", "Store 3", "Store 4"
            };
        }
    }
}