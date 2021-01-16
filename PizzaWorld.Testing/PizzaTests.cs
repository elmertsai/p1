using PizzaWorld.Domain.Models;
using Xunit;

namespace PizzaWorld.Testing
{
    public class PizzaTests
    {
        [Fact]
        private void Test_PizzaExists()
        {
            //arrange
           // sut: Subject Under Test
            var sut = new Pizza(); // inference

           // act
            var actual = sut;

           // assert
            Assert.IsType<Pizza>(actual);
            Assert.NotNull(actual);
        }

    }
}