using System.Collections.Generic;

namespace PizzaWorld.Domain.Abstracts
{
  public abstract class AProduct : AEntity
  {
    public string Name { get; set; }
    public double Price { get; set; }
  }
}
