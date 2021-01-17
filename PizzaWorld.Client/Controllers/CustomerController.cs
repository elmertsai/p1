using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PizzaWorld.Storing;
using PizzaWorld.Client.Models;

namespace PizzaWorld.Client.Controllers
{
[Route("[controller]")]
  public class CustomerController : Controller
  {
    private readonly PizzaWorldRepository _ctx;
    public CustomerController(PizzaWorldRepository context)
    {
      _ctx = context;
    }
    [Route("")]
    [HttpGet]
    public IActionResult Home()
    {
      var customer = new CustomerViewModel();

      customer.Order = new OrderViewModel()
      {
        Stores = _ctx.GetStoreNames().ToList()
      };

      return View("home", customer);
    }
  }
}
