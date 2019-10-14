using FluentAssertions;
using Xunit;

namespace StringCalculator.Tests
{
    public class StringCalculatorWithDelimitersTests
    {
        private readonly StringCalculatorWithDelimiters _sut;

        public StringCalculatorWithDelimitersTests()
        {
            _sut = new StringCalculatorWithDelimiters();
        }

        [Theory]
        [InlineData("", 0)]
        [InlineData("1", 1)]
        [InlineData("1;2", 3)]
        [InlineData("//ñ\n1ñ2", 3)]
        [InlineData("1;2;3", 6)]
        [InlineData("1;;3", 4)]
        [InlineData("  1 ;  3   ", 4)]
        [InlineData("1;3;i", 4)]
        public void Add_Should_Return_Valid_Results(string numbers, int expectedResult)
        {
            var result = _sut.Add(numbers);

            result.Should().Be(expectedResult);
        }
    }
}