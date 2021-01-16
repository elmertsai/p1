using PizzaWorld.Domain.Models;
using Xunit;

namespace PizzaWorld.Testing
{
    public class UserTests
    {
        [Fact]
        private void Test_UserExists()
        {
            // arrange
            // sut: Subject Under Test
            var sut = new Customer(); // inference

            // act
            var actual = sut;
            // assert
            Assert.IsType<Customer>(actual);
            Assert.NotNull(actual);
        }
        [Fact]
        private void Test_ToString()
        {
            // arrange
            // sut: Subject Under Test
            var sut = new Customer(); // inference

            // act
            var actual = sut.ToString();

            // assert
            Assert.IsType<string>(actual);
            Assert.NotNull(actual);
        }
    }
}