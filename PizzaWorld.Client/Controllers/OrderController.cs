using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaWorld.Client.Models;
using PizzaWorld.Domain.Models;
using PizzaWorld.Storing;

namespace PizzaWorld.Client.Controllers
{
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly PizzaWorldContext _ctx;

        public OrderController(PizzaWorldContext context)
        {
            _ctx = context;
            
        }
        [Route("[action]")]
        [HttpGet]
        public IActionResult Get()
        {
            return View("Order");
        }
        public IActionResult Get(string id)
        {
            return View("Order", new OrderViewModel());
        }
        [HttpPost]
        public IActionResult Post(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var order = new Order()
                {
                    Ordertime = DateTime.Now,
                    Store = _ctx.Stores.FirstOrDefault(s => s.Name == model.Store)
                };
                if(_ctx.Orders == null)
                {
                    Console.WriteLine("Context Order is Null");
                }

                _ctx.Orders.Add(order);
                _ctx.SaveChanges();

                return View("OrderPlaced");
            }
            return View("home", model);
        }
        // public IActionResult Index()
        // {
        //     return View();
        // }

        // public IActionResult Privacy()
        // {
        //     return View();
        // }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        // }
    }
}