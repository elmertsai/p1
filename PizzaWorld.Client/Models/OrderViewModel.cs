using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaWorld.Domain.Abstracts;
using PizzaWorld.Domain.Models;

namespace PizzaWorld.Client.Models
{
    public class OrderViewModel
    { 
        // public List<string> Stores { get; set; }
        public StoreViewModel StoreView {get;set;}

        // public List<APizzaModel> CurrentPizzas { get; set; } // List of pizzas within the order
        public List<PrebuiltPizza> PrebuiltPizzas { get; set; }
        public List<PizzaViewModel> PizzaViews { get; set; }

        public List<Topping> Toppings {get;set;} //list of toppings to choose from
        public List<Crust> Crusts { get; set; } //list of crusts to choose from
        public List<Size> Sizes {get;set;} // list of sizes to choose from
        public double Price {get;set;} //to be calculated at OrderReview

        public List<string> PizzaNames { get; set; }
        
        public string Store {get; set;}
        public string StoreSelection {get;set;}
        public string CustomerName {get; set;}
        public string CrustID { get; set; } 
        public string SizeID { get; set; }
        public List<string> ToppingNames { get; set;}
        public List<SelectListItem> ToppingSelectList { get; set; }

        

        public string pizza {get;set;}

    }
}