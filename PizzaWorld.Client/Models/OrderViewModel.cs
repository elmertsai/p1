using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaWorld.Domain.Models;

namespace PizzaWorld.Client.Models
{
    public class OrderViewModel
    { 
        public List<Store> Stores { get; set; }
        public List<Pizza> Pizzas { get; set; }
        
        [Required]
        public string Store {get; set;}
        public List<string> PizzaSelection { get; set; }
        public string StoreSelection {get;set;}
        public string Name {get; set;}

    }
}