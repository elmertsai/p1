using System.Collections.Generic;
using PizzaWorld.Domain.Models;

namespace PizzaWorld.Client.Models
{
    public class StoreViewModel // Analogous to sqlclient we have in p0
    {
        public List<string> Stores { get; set; } //List<Store> when domain is connected 
        public List<string> Addresses{ get; set; }
        public string SelectedStoreName { get; set;}
        public string SelectedStoreAddress { get; set;}
        public List<Store> StoreObjects { get; set; }
        public List<Order> StoreOrderHistory {get;set;}
        public double Revenue { get; set; }
        public StoreViewModel()
        {
        }
    }
}