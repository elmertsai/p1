using System.Collections.Generic;
using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models
{
    public class Customer : AEntity
    {
        public ICollection<Order> Orders { get; set; }
        public string Name { get; set; }
        public Store SelectedStore { get; set; }

        public Customer()
        {
            //Orders = new List<Order>();
        }

        public override string ToString()
        {
            if(Name != null)
            {
                return Name;
            }
            return "CustomerNameNotFound"; //$ String interpolation
        }
    
    }
}