using System.Collections.Generic;
using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models
{
  public class Topping : AProduct
  {
    public ICollection<APizzaModel> Pizzas {get;set;}
    public ICollection<PrebuiltPizza> PrebuiltPizzas { get; set; }
    
  }
}
