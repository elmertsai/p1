using System.Collections.Generic;

namespace PizzaWorld.Domain.Abstracts
{
  public abstract class AProduct : AEntity
  {
    public string name { get; set; }
    public double price { get; set; }
  }
}
