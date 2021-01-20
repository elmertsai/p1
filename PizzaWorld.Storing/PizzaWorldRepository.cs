using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaWorld.Domain.Abstracts;
using PizzaWorld.Domain.Models;

namespace PizzaWorld.Storing
{
  public class PizzaWorldRepository
  {
    private PizzaWorldContext _ctx;

    public PizzaWorldRepository(PizzaWorldContext context)
    {
      _ctx = context;
    }

    public List<string> GetStoreNames()
    {
      return _ctx.Stores.Select(s => s.Name).ToList();
    }
    public List<string> GetStoreAddresses()
    {
      return _ctx.Stores.Select(s => s.Address).ToList();
    }
    public List<string> GetPizzaNames()
    {
        return _ctx.Pizzas.Select(p => p.Name).ToList();    
    }
    public List<string> GetCustomerNames()
    {
      return _ctx.Customers.Select(c => c.Name).ToList();
    }

    

    public IEnumerable<Store> ReadStores()
    {

        return _ctx.Stores
                    .Include(u => u.Orders).ThenInclude(o => o.Pizzas).ThenInclude(p => p.Toppings)
                    .Include(u => u.Orders).ThenInclude(o => o.Pizzas).ThenInclude(p => p.Crust)
                    .Include(u => u.Orders).ThenInclude(o => o.Pizzas).ThenInclude(p => p.Size)
                    .Include(u => u.Orders).ThenInclude(o => o.Store)
                    .ToList();
 
    }
    public IEnumerable<Order> GetStoreOrders(string storeName)
    {
        return _ctx.Stores
                    .Include(u => u.Orders).ThenInclude(o => o.Pizzas).ThenInclude(p => p.Toppings)
                    .Include(u => u.Orders).ThenInclude(o => o.Pizzas).ThenInclude(p => p.Crust)
                    .Include(u => u.Orders).ThenInclude(o => o.Pizzas).ThenInclude(p => p.Size)
                    .FirstOrDefault(s=>s.Name==storeName).Orders;
    }
    public IEnumerable<APizzaModel> ReadPizzas()
    {
        return _ctx.Pizzas.ToList();
    }
    public IEnumerable<Order> ReadOrders()
    {
        return _ctx.Orders.Include(o=>o.Pizzas)
                            .ToList();
                            
    }
    public IEnumerable<PrebuiltPizza> ReadPrebuiltPizzas()
    {
        return _ctx.PrebuiltPizzas.Include(p=>p.Crust)
                                  .Include(p=>p.Size)
                                  .Include(p=>p.Toppings);
    }
    public IEnumerable<Crust> ReadCrust()
    {
        return _ctx.Crusts.ToList();
    }
    public IEnumerable<Topping> ReadTopping()
    {
        return _ctx.Toppings.ToList();
    }
    public IEnumerable<Customer> ReadCustomers()
    {
        var users = _ctx.Customers
                    .Include(u => u.Orders).ThenInclude(o => o.Pizzas).ThenInclude(p => p.Toppings)
                    .Include(u => u.Orders).ThenInclude(o => o.Pizzas).ThenInclude(p => p.Crust)
                    .Include(u => u.Orders).ThenInclude(o => o.Pizzas).ThenInclude(p => p.Size)
                    .Include(u => u.Orders).ThenInclude(o => o.Store)
                    .ToList();
        return users;
    }
    public IEnumerable<Size> ReadSize()
    {
        return _ctx.Sizes.ToList();
    }   
    public void Save(Store store)
    {
      _ctx.Stores.Add(store); 
      _ctx.Database.OpenConnection();
    try
    {
        _ctx.SaveChanges();
    }
    finally
    {
        _ctx.Database.CloseConnection();
    }
    }
    public void Save(Order order)
    {
        _ctx.Orders.Add(order);
    try
    {
        _ctx.SaveChanges();
    }
    finally
    {
        _ctx.Database.CloseConnection();
    }
    }
    public void Save(PrebuiltPizza pizza)
    {
        _ctx.PrebuiltPizzas.Add(pizza);
    try
    {
        _ctx.SaveChanges();
    }
    finally
    {
        _ctx.Database.CloseConnection();
    }
    }
    public void Save(Customer customer)
    {
        _ctx.Customers.Add(customer);
        _ctx.Database.OpenConnection();
        try
        {
            _ctx.SaveChanges();
        }
        finally
        {
            _ctx.Database.CloseConnection();
        }
    }
    public void Save(APizzaModel pizza)
    {
        _ctx.Pizzas.Add(pizza);
        _ctx.Database.OpenConnection();
    try
    {
        _ctx.SaveChanges();
    }
    finally
    {
        _ctx.Database.CloseConnection();
    }
    }
    // Save changes to the database
    public void UpdateCustomer(Customer customer)
    {
        var u =  _ctx.Customers.ToList().FirstOrDefault(x => x.Name==customer.Name);
        if(u==null)
        {
            System.Console.WriteLine("Warning... username not found in db");
        }
        else
        {
            u.Orders = customer.Orders;
            u.SelectedStore = customer.SelectedStore;
            _ctx.SaveChanges();
        }
    }
    public void Update()
    {
        _ctx.SaveChanges();
    }
    public void UpdateStore(Store store)
    {
        var s =  _ctx.Stores.ToList().FirstOrDefault(x => x.EntityID==store.EntityID);
        if(s==null)
        {
            System.Console.WriteLine("Warning... store not found in db");
        }
        else
        {
            s.Orders = store.Orders;
            _ctx.SaveChanges();
        }
    }
    public Order GetLastOrder()
    {
        return _ctx.Orders.Include(o=>o.Pizzas).ThenInclude(p=>p.Crust)
                          .Include(o=>o.Pizzas).ThenInclude(p=>p.Size)
                          .Include(o=>o.Pizzas).ThenInclude(p=>p.Toppings)
                          .ToList().Last();
    }
    public void UpdateOrder(Order order)
    {
      //Change the last order on the list of order *might not be viable with many users*
      var o = _ctx.Orders.Last();
      o = order;
      _ctx.SaveChanges();
    }
    public void PrebuiltPizza()
        {
            if(ReadPrebuiltPizzas().Count()==0)
            {
                Console.WriteLine("No Pizza found in DB! Adding pizzas");
                Crust c=ReadCrust().FirstOrDefault(x => x.Name.Contains("Hand Tossed"));
                Size s=ReadSize().FirstOrDefault(x => x.Name.Contains("Medium"));
                Topping t1 =ReadTopping().FirstOrDefault(x => x.Name.Contains("Premium Chicken"));
                Topping t2 =ReadTopping().FirstOrDefault(x => x.Name.Contains("Cheese"));
                List<Topping> t = new List<Topping>{t1,t2};
                PrebuiltPizza meatpizza1 = new PrebuiltPizza(c,s,t);
                meatpizza1.Name = "Medium Hand Tossed Meat Pizza";
                Save(meatpizza1);

                
                c=ReadCrust().FirstOrDefault(x => x.Name.Contains("Cheese-Stuffed"));
                s=ReadSize().FirstOrDefault(x => x.Name.Contains("Large"));
                t1 =ReadTopping().FirstOrDefault(x => x.Name.Contains("Premium Chicken"));
                t2 =ReadTopping().FirstOrDefault(x => x.Name.Contains("Cheese"));
                Topping t3 = ReadTopping().FirstOrDefault(x => x.Name.Contains("Pulled Pork"));
                Topping t4 = ReadTopping().FirstOrDefault(x => x.Name.Contains("Mushroom"));
                t = new List<Topping>{t1,t2,t3,t4};
                PrebuiltPizza meatpizza2 = new PrebuiltPizza(c,s,t);
                meatpizza2.Name = "Large Cheese Stuffed King of Pizza";
                Save(meatpizza2);

                c=ReadCrust().FirstOrDefault(x => x.Name.Contains("Thin"));
                s=ReadSize().FirstOrDefault(x => x.Name.Contains("Small"));
                t1 =ReadTopping().FirstOrDefault(x => x.Name.Contains("Cheese"));
                t = new List<Topping>{t1};
                PrebuiltPizza cheesepizza = new PrebuiltPizza(c,s,t);
                cheesepizza.Name = "Small thin crust cheese pizza";
                Save(cheesepizza);
            }
            else
            {
                Console.WriteLine("All set! Welcome to the Pizza Ordering App!");
            }
        }
}
}
