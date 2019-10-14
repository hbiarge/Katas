using FluentAssertions;
using Xunit;

namespace StringCalculator.Tests
{
    public class StringCalculatorTests
    {
        private readonly StringCalculator _sut;

        public StringCalculatorTests()
        {
            _sut = new StringCalculator();
        }

        //[Fact]
        //public void Empty_string_return_0()
        //{
        //    var result = _sut.Add(string.Empty);

        //    result.Should().Be(0);
        //}

        //[Fact]
        //public void String_with_One_Number_Returns_The_Number()
        //{
        //    var result = _sut.Add("1");

        //    result.Should().Be(1);
        //}

        [Theory]
        [InlineData("", 0)]
        [InlineData("1", 1)]
        [InlineData("1,2", 3)]
        [InlineData("1,2,3", 6)]
        [InlineData("1,,3", 4)]
        [InlineData("  1 ,  3   ", 4)]
        [InlineData("1,3,i", 4)]
        public void Add_Should_Return_Valid_Results(string numbers, int expectedResult)
        {
            var result = _sut.Add(numbers);

            result.Should().Be(expectedResult);
        }
    }
}
