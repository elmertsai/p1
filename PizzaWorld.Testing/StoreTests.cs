using System.Collections.Generic;
using System.Linq;
using PizzaWorld.Domain.Abstracts;
using PizzaWorld.Domain.Models;
using Xunit;

namespace PizzaWorld.Testing
{
    public class StoreTests
    {
        [Fact]
        private void Test_StoreExists()
        {
            // arrange
            // sut: Subject Under Test
            var sut = new Store(); // inference

            // act
            var actual = sut;

            // assert
            Assert.IsType<Store>(actual);
            Assert.NotNull(actual);
        }
        [Fact]
        private void Test_CreateOrder()
        {
            
            // arrange
            // sut: Subject Under Test
            List<APizzaModel> aPizzas = new List<APizzaModel>(); 
            Customer user = new Customer();
            var sut = new Store(); 
            sut.CreateOrder(aPizzas,user);

            // act
            var actual = sut;

            // assert
            Assert.IsType<Store>(actual);
            Assert.NotEmpty(actual.Orders);
        }
        [Fact]
        private void Test_ToString()
        {
            var sut = new Store(); 
            

            // act
            var actual = sut.ToString();

            // assert
            Assert.IsType<string>(actual);
            Assert.NotNull(actual);
        }
        [Fact]
        private void Test_DeleteOrder()
        {
            var sut = new Store(); 
            Order order= new Order();
            sut.Orders.Add(order);
            sut.DeleteOrder(order);
        
            // act
            var actual = sut.Orders;

            // assert
            Assert.Empty(actual);
            System.Console.WriteLine("oi");
        }
        
    }
}