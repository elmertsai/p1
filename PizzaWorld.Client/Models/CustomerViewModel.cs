using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;
using PizzaWorld.Domain.Models;

namespace PizzaWorld.Client.Models
{
  public class CustomerViewModel
  {
    public string Name { get; set; }
    public OrderViewModel Order { get; set; }
    public Customer Customer { get; set; } // selected by post
    public List<Customer> Customers {get;set;} // injected from repo
    public string CustomerID {get;set;}
    public StoreViewModel StoreView { get; set; }
    public string store {get;set;}

    public CustomerViewModel()
    {
      Name = "Customer";
      Order = new OrderViewModel();
    }
  }
}
