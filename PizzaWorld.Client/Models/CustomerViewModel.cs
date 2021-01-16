using Microsoft.Extensions.Configuration;

namespace PizzaWorld.Client.Models
{
  public class CustomerViewModel
  {
    public string Name { get; set; }
    public OrderViewModel Order { get; set; }

    public CustomerViewModel()
    {
      Name = "Elmer";
      Order = new OrderViewModel();
    }
  }
}
