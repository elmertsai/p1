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
      Crust = c;
      Size = s;
      Toppings = t;
      SetPrice();
    }
    protected override void SetName(string n)
    {
      this.Name = n;
    }

    public override void SetPrice()
    {
      double sum=0;
      foreach (var item in Toppings)
      {
          sum += item.Price;
      }
      sum += Size.Price;
      sum += Crust.Price;
      Price = sum+10;
    }
    protected override void AddCrust(Crust c) 
    { 
      Crust = c;
    }
    protected override void AddSize(Size s) 
    { 
      Size=s;
    }
    protected override void AddToppings(List<Topping> t) 
    { 
      Toppings = t;
    }
  }
}
