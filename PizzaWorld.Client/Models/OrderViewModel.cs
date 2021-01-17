using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaWorld.Domain.Models;

namespace PizzaWorld.Client.Models
{
    public class OrderViewModel
    { 
        public List<string> Stores { get; set; }

        public List<Pizza> Pizzas { get; set; }
        
        [Required]
        public string Store {get; set;}
        public List<string> PizzaSelection { get; set; }
        public string StoreSelection {get;set;}
        public string Name {get; set;}
        // public OrderViewModel()
        // {
        //     Stores = new List<Store>()
        //     {
        //         new Store(){Name = "Store1"}
        //         ,new Store(){Name = "Store2"}
        //         ,new Store(){Name = "Store3"}

        //     };
        // }

    }
}