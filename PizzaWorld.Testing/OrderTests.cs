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
            List<APizzaModel> p = new List<APizzaModel>();
            APizzaModel pizza = new Pizza();
            pizza.price = 20;
            p.Add(pizza);
            sut.CalculatePrice();
            var actual = sut.price;

            Assert.IsType<double>(actual);
            //Assert.NotNull(actual);
        }
        [Fact]
        private void Test_ToString()
        {
            // arrange
            // sut: Subject Under Test
            var sut = new Order(); // inference

            // act
            var actual = sut.ToString();

            // assert
            Assert.IsType<string>(actual);
            Assert.NotNull(actual);
        }
    }
}