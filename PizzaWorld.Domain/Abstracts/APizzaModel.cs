using System.Collections.Generic;
using PizzaWorld.Domain.Models;

namespace PizzaWorld.Domain.Abstracts
{
  public class APizzaModel : AProduct
  {
    public Crust Crust { get; set; }
    public Size Size { get; set; }
    public ICollection<Topping> Toppings { get; set; }
    public ICollection<Order> Orders { get; set; }

    // public long CrustEntityID { get; set; }
    // public long SizeEntityID {get;set;}

    public virtual void SetPrice()
    { 
    }
    protected virtual void SetName(string str)
    {

    }
    protected virtual void AddCrust(Crust c) { }
    protected virtual void AddSize(Size s) { }
    protected virtual void AddToppings(List<Topping> t) { }
  }
}
