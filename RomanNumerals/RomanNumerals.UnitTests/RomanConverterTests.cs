using FluentAssertions;
using Xunit;

namespace RomanNumerals.UnitTests
{
    public class RomanConverterTests
    {
        private RomanConverter _converter;

        public RomanConverterTests()
        {
            _converter = new RomanConverter();
        }

        [Theory]
        [InlineData(1, "I")]
        [InlineData(2, "II")]
        [InlineData(3, "III")]
        [InlineData(4, "IV")]
        [InlineData(5, "V")]
        [InlineData(6, "VI")]
        [InlineData(7, "VII")]
        [InlineData(8, "VIII")]
        [InlineData(9, "IX")]
        [InlineData(10, "X")]
        [InlineData(13, "XIII")]
        [InlineData(20, "XX")]
        [InlineData(23, "XXIII")]
        [InlineData(30, "XXX")]
        [InlineData(33, "XXXIII")]
        [InlineData(40, "XL")]
        [InlineData(44, "XLIV")]
        [InlineData(50, "L")]
        [InlineData(90, "XC")]
        [InlineData(100, "C")]
        [InlineData(400, "CD")]
        [InlineData(500, "D")]
        [InlineData(900, "CM")]
        [InlineData(1000, "M")]
        [InlineData(846, "DCCCXLVI")]
        [InlineData(1999, "MCMXCIX")]
        [InlineData(2008, "MMVIII")]

        public void Can_Convert(int number, string expected)
        {
            var romanNumeral = _converter.Convert(number);

            romanNumeral.Should().Be(expected);
        }
    }
}
