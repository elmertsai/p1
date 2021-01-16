using System.Collections.Generic;
using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models
{
    public class Customer : AEntity
    {
        public List<Order> Orders { get; set; }
        public string Name { get; set; }
        public Store SelectedStore { get; set; }

        public Customer()
        {
            //Orders = new List<Order>();
        }

        public override string ToString()
        {
            return $"I have selected this store: {SelectedStore.Name}"; //$ String interpolation
        }
    
    }
}