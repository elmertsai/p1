using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PizzaWorld.Domain.Abstracts;
using PizzaWorld.Domain.Models;

namespace PizzaWorld.Storing
{
    public class PizzaWorldContext : DbContext
    {
        public DbSet<Store> Stores { get; set; }    
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Crust> Crusts { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<APizzaModel> Pizzas { get; set; }
        public DbSet<Order> Orders {get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=elmerpizzaworlddb.database.windows.net;Initial Catalog=PizzaWorldDbDemo;User ID=sqladmin;Password=Ppp12312344;");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Store>().HasKey(s => s.EntityID);
            builder.Entity<Customer>().HasKey(u => u.EntityID);
            builder.Entity<APizzaModel>().HasKey(p => p.EntityID);
            builder.Entity<Order>().HasKey(o => o.EntityID);
            builder.Entity<Crust>().HasKey(c => c.EntityID);
            builder.Entity<Topping>().HasKey(t => t.EntityID);
            builder.Entity<Size>().HasKey(size => size.EntityID);


            SeedData(builder);
        }
        protected void SeedData(ModelBuilder builder)
        {
            builder.Entity<Store>().HasData(new List<Store>
            {
            new Store() { Name = "One", Address = "Store 1 Address", EntityID =1},
            new Store() { Name = "Two", Address = "Store 2 Address", EntityID =2},
            new Store() { Name = "Three", Address = "Store 3 Address",EntityID = 3}
            }
            );
            builder.Entity<Crust>().HasData(new List<Crust>
            {
                new Crust() { name = "Thin",price = 0,EntityID=1},
                new Crust() { name = "Hand Tossed",price = 0,EntityID=2},
                new Crust() { name = "Cheese-Stuffed",price = 2,EntityID=3}
            }
            );
            builder.Entity<Size>().HasData(new List<Size>
            {
                new Size() { name = "Small",price = 0,EntityID=1},
                new Size() { name = "Medium",price = 3,EntityID =2},
                new Size() { name = "Large",price = 5,EntityID =3}
            }
            );
            builder.Entity<Topping>().HasData(new List<Topping>
            {
                new Topping() { name = "Cheese",price = 0,EntityID=1},
                new Topping() { name = "Premium Chicken",price = 2,EntityID=2},
                new Topping() { name = "Pulled Pork",price = 2,EntityID=3},
                new Topping() { name = "Mushroom",price = 0,EntityID=4}
            }
            );
            builder.Entity<Customer>().HasData(new List<Customer>
            {
                new Customer() { Name = "Elmer",EntityID=1},
                new Customer() { Name = "Elmer2",EntityID=2},
                new Customer() { Name = "user3",EntityID=3}
            }
            );
        }
    }
}