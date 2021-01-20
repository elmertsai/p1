using System.Collections.Generic;
using PizzaWorld.Domain.Abstracts;
using PizzaWorld.Domain.Models;
using Xunit;

namespace PizzaWorld.Testing
{
    public class OrderTests
    {
        [Fact]
        private void Test_OrderExists()
        {
            // arrange
            // sut: Subject Under Test
            var sut = new Order(); // inference
            // act
            var actual = sut;

            // assert
            Assert.IsType<Order>(actual);
            Assert.NotNull(actual);
        }
        [Fact]
        private void Test_CalculatePrice()
        {
            var sut = new Order();
            sut.Pizzas = new List<APizzaModel>();
            APizzaModel pizza = new Pizza();
            pizza.Price = 20;
            sut.Pizzas.Add(pizza);
            sut.CalculatePrice();
            var actual = sut.Price;

            Assert.IsType<double>(actual);
        }
    }
}