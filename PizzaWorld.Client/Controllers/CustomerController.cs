using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PizzaWorld.Storing;
using PizzaWorld.Client.Models;
using System;

namespace PizzaWorld.Client.Controllers
{
[Route("[controller]")]
  public class CustomerController : Controller
  {
    private readonly PizzaWorldRepository _repo;
    public CustomerController(PizzaWorldRepository repo)
    {
      _repo = repo;
    }
    [Route("")]
    [Route("[action]")]
    [HttpGet]
    public IActionResult Home()
    {
      var customer = new CustomerViewModel()
      {
        Customers = _repo.ReadCustomers().ToList()
        ,StoreView = new StoreViewModel()
      };
      customer.StoreView.Stores = _repo.GetStoreNames().ToList();
      customer.StoreView.Addresses = _repo.GetStoreAddresses().ToList();
      customer.StoreView.StoreObjects= _repo.ReadStores().ToList();

      customer.Order = new OrderViewModel()
      {
        PizzaNames = _repo.GetPizzaNames().ToList()
        ,PrebuiltPizzas = _repo.ReadPrebuiltPizzas().ToList()
        ,Toppings = _repo.ReadTopping().ToList()
      };

      return View("home", customer);
    }
    [Route("[action]")]
    [HttpGet]
    public IActionResult CustomerOrderHistory()
    {

      var customer = new CustomerViewModel()
      {
        Name = TempData.Peek("CustomerName") as string
      };
      customer.Customer = _repo.ReadCustomers().FirstOrDefault(c=>c.Name==customer.Name);
      if(customer.Customer == null)
      {
        Console.WriteLine("Repo return null for customer");
      }
      return View("CustomerOrderHistory",customer);

    }
  }
}
