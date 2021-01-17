using System.Collections.Generic;
using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models
{
    public class PrebuiltPizza : AProduct
  {    
    public Crust Crust { get; set; }
    public Size Size { get; set; }
    public ICollection<Topping> Toppings { get; set; }

    public PrebuiltPizza()
    {
  
    }
    public PrebuiltPizza(Crust c, Size s,List<Topping> t)
    {
      Crust = c;
      Size = s;
      Toppings = t;
      SetPrice();
    }
    protected void SetName(string n)
    {
      this.Name = n;
    }

    public void SetPrice()
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
    protected void AddCrust(Crust c) 
    { 
      Crust = c;
    }
    protected void AddSize(Size s) 
    { 
      Size=s;
    }
    protected void AddToppings(List<Topping> t) 
    { 
      Toppings = t;
    }
  }
}
