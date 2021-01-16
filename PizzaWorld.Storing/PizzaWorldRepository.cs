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
    public List<string> GetPizzaNames()
    {
        return _ctx.Pizzas.Select(p => p.name).ToList();    
    }
    public List<string> GetCustomerNames()
    {
      return _ctx.Customers.Select(c => c.Name).ToList();
    }

    

    public IEnumerable<Store> ReadStores()
    {

        return _ctx.Stores.Include(s=>s.Orders);
 
    }
    public IEnumerable<APizzaModel> ReadPizzas()
    {
        return _ctx.Pizzas.ToList();
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
                    .Include(u => u.Orders)
                    .ThenInclude(o => o.Pizzas)
                    .ToList();
        return users;
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
    public void UpdateOrder(Order order)
    {
      //Change the last order on the list of order *might not be viable with many users*
      var o = _ctx.Orders.Last();
      o = order;
      _ctx.SaveChanges();
    }
}
}
