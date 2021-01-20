
using System;
using System.Collections.Generic;
using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models
{
    public class Store : AEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<Order> Orders {get;set;}
    
        public Store()
        {
            Name = "Default Name";
            Address = "Default Address";
            // if(Orders==null)
            // {
                Orders = new List<Order>();
            // }
        }
        public void CreateOrder(List<APizzaModel> aPizzas, Customer customer)
        {
            Order o = new Order(aPizzas);
            o.Store = this;
            o.CalculatePrice();
            o.Customer = customer;
            Console.WriteLine("Create OrderCheck");

            Orders.Add(o);
            // System.Console.WriteLine(Orders.Count);
            // System.Console.WriteLine(o);
        }
        public bool DeleteOrder(Order order)
        {
            
            try
            {
                Orders.Remove(order);
                return true;
            }
            catch (System.Exception)
            {
                
                return false;
            }
           

        }
        public override string ToString()
        {
            return Name;
        }
    }
}