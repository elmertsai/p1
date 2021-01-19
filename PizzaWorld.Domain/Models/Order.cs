using System;
using System.Collections.Generic;
using PizzaWorld.Domain.Abstracts;
using PizzaWorld.Domain.Factories;

namespace PizzaWorld.Domain.Models
{
    
    public class Order : AEntity
    {
       // private GenericPizzaFactory _pizzaFactory = new GenericPizzaFactory();

        public ICollection<APizzaModel> Pizzas {get;set;}
        public Customer Customer { get; set; }
        public Store Store {get;set;}

        public double Price { get; set; }
        public DateTime Ordertime { get; set; }
        public Order()
        {
            Ordertime = DateTime.Now;
        }

        public Order(List<APizzaModel> p)
        {
            Pizzas = p;
            Ordertime = DateTime.Now;
            CalculatePrice();
        }
        public void CalculatePrice()
        {
            double sum=0;
            foreach (var item in Pizzas)
            {
                sum += item.Price;
            }
            Price = sum;
        }

        public override string ToString()
        {
            var sb = new System.Text.StringBuilder();
            int counter = 1;
            sb.Append(String.Format("{0,-25} {1,-25} {2,-25}\n\n","Customer name","Order Time","Total Price"));
            sb.Append(String.Format("{0,-25} {1,-25} {2,-25}\n",Customer.Name,Ordertime,"$"+Price));
            sb.Append(String.Format("{0,-15} {1,-15} {2,-15}\n\n","Number","Pizza name","Price"));
            foreach(var p in Pizzas)
            {
                sb.Append(String.Format("{0,-15} {1,-15} {2,-15}\n",counter,p.Name,p.Price));
                counter++;
            } 
            return sb.ToString();
        }


    }
}