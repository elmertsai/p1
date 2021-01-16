using System.Collections.Generic;
using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models
{
    public class Pizza : APizzaModel
  {    


    public Pizza()
    {
   
    }
    public Pizza(Crust c, Size s,List<Topping> t)
    {
      crust = c;
      size = s;
      toppings = t;
      SetPrice();
    }
    protected override void SetName(string n)
    {
      this.name = n;
    }

    public override void SetPrice()
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
    protected override void AddCrust(Crust c) 
    { 
      crust = c;
    }
    protected override void AddSize(Size s) 
    { 
      size=s;
    }
    protected override void AddToppings(List<Topping> t) 
    { 
      toppings = t;
    }
  }
}
