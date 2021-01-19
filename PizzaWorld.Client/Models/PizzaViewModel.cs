using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaWorld.Domain.Abstracts;
using PizzaWorld.Domain.Models;

namespace PizzaWorld.Client.Models
{
    public class PizzaViewModel
    { 

        public List<Topping> Toppings {get;set;}
        public List<Crust> Crusts { get; set; }
        public List<Size> Sizes {get;set;}

        public List<string> PizzaNames { get; set; }
        
        public string Name {get; set;}
        public string Crust { get; set; } 
        public string Size { get; set; }
        public double Price{get;set;}
        public List<string> ToppingNames { get; set;}
        public List<SelectListItem> ToppingSelectList { get; set; }

        public string pizza {get;set;}


    }
}