using System.Collections.Generic;
using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models
{
    public class PrebuiltPizza : AProduct
  {    
    public Crust crust { get; set; }
    public Size size { get; set; }
    public List<Topping> toppings { get; set; }

    public PrebuiltPizza()
    {
   
    }
    public PrebuiltPizza(Crust c, Size s,List<Topping> t)
    {
      crust = c;
      size = s;
      toppings = t;
      SetPrice();
    }
    protected void SetName(string n)
    {
      this.name = n;
    }

    public void SetPrice()
    {
      double sum=0;
      foreach (var item in toppings)
      {
          sum += item.price;
      }
      sum += size.price;
      sum += crust.price;
      price = sum+10;
    }
    protected void AddCrust(Crust c) 
    { 
      crust = c;
    }
    protected void AddSize(Size s) 
    { 
      size=s;
    }
    protected void AddToppings(List<Topping> t) 
    { 
      toppings = t;
    }
  }
}
