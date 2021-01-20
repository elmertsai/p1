using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using PizzaWorld.Client.Models;
using PizzaWorld.Domain.Abstracts;
using PizzaWorld.Domain.Models;
using PizzaWorld.Storing;

namespace PizzaWorld.Client.Controllers
{
    [Route("[controller]")]
    public class OrderController : Controller
    {
        // private readonly PizzaWorldContext _ctx;
        private readonly PizzaWorldRepository _repo;

        public OrderController(PizzaWorldRepository repo)
        {
            _repo = repo;
        }
        
        [HttpGet]
        [Route("[action]")]
        public IActionResult OrderReview(OrderViewModel model)
        {
            var order = _repo.GetLastOrder(); // some way of getting the current order
            
            model.PizzaViews = new List<PizzaViewModel>();
            
            foreach (var pizza in order.Pizzas)
            {
            var a =new PizzaViewModel()
            {
                Crust = pizza.Crust.Name
                ,Size = pizza.Size.Name
                ,Price = pizza.Price
                ,ToppingNames = new List<string>()
                           
            }; 
            foreach (var item in pizza.Toppings)
            {
                a.ToppingNames.Add(item.Name);       
            };
            model.PizzaViews.Add(a);
            };

           
            return View("OrderReview",model);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult OrderComplete(OrderViewModel model)
        {      
            model.CustomerName = TempData.Peek("CustomerName") as string;
            return View("OrderPass",model);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult OrderPrebuiltPizza()
        {
            var model = new OrderViewModel()
            {
                // Stores = _repo.GetStoreNames().ToList()
                PizzaNames = _repo.GetPizzaNames().ToList()
                ,PrebuiltPizzas = _repo.ReadPrebuiltPizzas().ToList()
                ,Toppings = _repo.ReadTopping().ToList()
            };
            
            return View("OrderPrebuiltPizza",model);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult OrderCustomPizza()
        {


            var model = new OrderViewModel()
            {
                // Stores = _repo.GetStoreNames().ToList()
                PizzaNames = _repo.GetPizzaNames().ToList()
                ,PrebuiltPizzas = _repo.ReadPrebuiltPizzas().ToList()
                ,Toppings = _repo.ReadTopping().ToList()
                ,Crusts = _repo.ReadCrust().ToList()
                ,Sizes = _repo.ReadSize().ToList()
            };
            model.ToppingSelectList = new List<SelectListItem>();
            foreach (var item in model.Toppings)
            {
                model.ToppingSelectList.Add(new SelectListItem
                {
                    Text =item.Name,
                    Value = item.EntityID.ToString()
                });
            }
            
            return View("OrderCustomPizza",model);
        }
        
        
        
        [Route("[action]")]
        [HttpPost]
        public IActionResult PostOrderSetup(CustomerViewModel model)
        {

            if (ModelState.IsValid)
            {
        
                long.TryParse(model.CustomerID,out var customerID);
                var order = new Order()
                {
                    Ordertime = DateTime.Now
                    ,Store = _repo.ReadStores().FirstOrDefault(s => s.Name == model.store)
                    ,Customer = _repo.ReadCustomers().FirstOrDefault(c=> c.EntityID == customerID)     
                };
                if(_repo.ReadOrders() == null)
                {
                    Console.WriteLine("Context Order is Null");

                }
                
                
                model.Order.Store = model.store;
                TempData["StoreName"] = model.store;
                TempData["CustomerName"] = order.Customer.Name;

                // var o = _repo.ReadOrders().ToList();
                
                // o.Add(order);
                
                _repo.Save(order);

                return View("OrderMenu",model.Order);
            }
            return View("home", model);
        }
        [Route("[action]")]
        [HttpPost]
        public IActionResult AddPrebuiltPizza(OrderViewModel model)
        {

            if (ModelState.IsValid)
            {
                var order = _repo.GetLastOrder(); //need to get order ID somehow
                long pizzaLong = long.Parse(model.pizza);
                var prebuiltpizza =_repo.ReadPrebuiltPizzas().First(s => s.EntityID == pizzaLong);
                APizzaModel pizza = new Pizza();
                pizza.Crust= prebuiltpizza.Crust;
                pizza.Size = prebuiltpizza.Size;
                pizza.Toppings = prebuiltpizza.Toppings;
                pizza.Name = prebuiltpizza.Name;
                pizza.SetPrice();

                // var temporder = TempData.Get<Order>("TempOrder");
                // if(temporder ==null)
                // {
                //     Console.WriteLine("Something went wrong with storing temporder");
                // }
                // if(temporder.Pizzas==null)
                // {
                //     temporder.Pizzas = new List<APizzaModel>();
                // }
                // temporder.Pizzas.Add(pizza);
                // temporder.CalculatePrice();
                // model.Price = temporder.Price;
                // Console.WriteLine("The temporder has this many pizzas: "+ temporder.Pizzas.Count);

                if(order.Pizzas==null)
                {
                    order.Pizzas = new List<APizzaModel>();
                }
                order.Pizzas.Add(pizza);
                order.CalculatePrice();
                model.Price = order.Price;
                _repo.Update();
                model.PizzaViews = new List<PizzaViewModel>();
                
                foreach (var item in order.Pizzas)
                {
                    var a =new PizzaViewModel()
                    {
                        Name = item.Name
                        ,Crust = item.Crust.Name
                        ,Size = item.Size.Name
                        ,Price = item.Price
                        ,ToppingNames = new List<string>()
                                
                    }; 
                    foreach (var item2 in item.Toppings)
                    {
                        a.ToppingNames.Add(item2.Name);       
                    };
                    model.PizzaViews.Add(a);
                };
                    return View("OrderMenu",model);
            }
            return View("home", model);
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult AddCustomPizza(OrderViewModel model)
        {

            if (ModelState.IsValid)
            {
                var order = _repo.GetLastOrder();
                Console.WriteLine(model.ToppingSelectList);
                List<Topping> toppings= new List<Topping>();
                foreach (var item in model.ToppingSelectList)
                {
                    var toppingID = long.Parse(item.Value);
                    if(item.Selected)
                    {
                        var topping = _repo.ReadTopping().FirstOrDefault(t => t.EntityID == toppingID);
                        toppings.Add(topping);
                    }
                }
                long.TryParse(model.CrustID,out var crustID);
                var crust = _repo.ReadCrust().FirstOrDefault(c=>c.EntityID==crustID);

                long.TryParse(model.SizeID,out var sizeID);
                var size = _repo.ReadSize().FirstOrDefault(s=>s.EntityID==sizeID);
                APizzaModel pizza = new Pizza();
                pizza.Crust= crust;
                pizza.Size = size;
                pizza.Toppings = toppings;
                pizza.Name = "CustomPizza";
                if(crust==null || size== null||toppings ==null)
                {
                    Console.WriteLine("Bad Pizza, something is  Null");
                }
                pizza.SetPrice();
                if(order.Pizzas==null)
                {
                    order.Pizzas = new List<APizzaModel>();
                }
                order.Pizzas.Add(pizza);
                order.CalculatePrice();
                model.Price = order.Price;
                _repo.Update();
                
                model.PizzaViews = new List<PizzaViewModel>();
                
                foreach (var item in order.Pizzas)
                {
                    var a =new PizzaViewModel()
                    {
                        Name = item.Name
                        ,Crust = item.Crust.Name
                        ,Size = item.Size.Name
                        ,Price = item.Price
                        ,ToppingNames = new List<string>()
                                
                    }; 
                    foreach (var item2 in item.Toppings)
                    {
                        a.ToppingNames.Add(item2.Name);       
                    };
                    model.PizzaViews.Add(a);
                };

                return View("OrderMenu",model);
            }
            return View("home", model);
        }
    }
}