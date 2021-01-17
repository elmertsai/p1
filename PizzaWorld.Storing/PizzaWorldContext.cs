using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PizzaWorld.Domain.Abstracts;
using PizzaWorld.Domain.Models;

namespace PizzaWorld.Storing
{
    public class PizzaWorldContext : DbContext
    {
        public DbSet<PrebuiltPizza> PrebuiltPizzas{get;set;}
        public DbSet<Store> Stores { get; set; }    
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Crust> Crusts { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<APizzaModel> Pizzas { get; set; }
        public DbSet<Order> Orders {get;set;}
        public PizzaWorldContext(DbContextOptions<PizzaWorldContext> options) : base(options) { }
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
            builder.Entity<PrebuiltPizza>().HasKey(p => p.EntityID);
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
                new Crust() { Name = "Thin",Price = 0,EntityID=1},
                new Crust() { Name = "Hand Tossed",Price = 0,EntityID=2},
                new Crust() { Name = "Cheese-Stuffed",Price = 2,EntityID=3}
            }
            );
            builder.Entity<Size>().HasData(new List<Size>
            {
                new Size() { Name = "Small",Price = 0,EntityID=1},
                new Size() { Name = "Medium",Price = 3,EntityID =2},
                new Size() { Name = "Large",Price = 5,EntityID =3}
            }
            );
            builder.Entity<Topping>().HasData(new List<Topping>
            {
                new Topping() { Name = "Cheese",Price = 0,EntityID=1},
                new Topping() { Name = "Premium Chicken",Price = 2,EntityID=2},
                new Topping() { Name = "Pulled Pork",Price = 2,EntityID=3},
                new Topping() { Name = "Mushroom",Price = 0,EntityID=4},
                new Topping() { Name = "Ham", Price = 1, EntityID = 5},
                new Topping() { Name = "Pineapple", Price = 1, EntityID = 6}
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