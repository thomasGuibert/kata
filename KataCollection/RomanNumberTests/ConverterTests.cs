using RomanNumber;
using Xunit;

namespace RomanNumberTests
{
    public class ConverterTests
    {
        private readonly RomanNumberConverter _converter = new RomanNumberConverter();

        [Fact]
        public void GivenNumber0_WhenConvert_ShouldBeEmpty()
        {
            var convertedNumber = _converter.ConvertDigit(0);
            Assert.Equal("", convertedNumber);

        }
        [Fact]
        public void GivenNumber1_WhenConvert_ShouldBeI()
        {
            var convertedNumber = _converter.ConvertDigit(1);
            Assert.Equal("I", convertedNumber);
        }

        [Fact]
        public void GivenNumber2_WhenConvert_ShouldBeII()
        {
            var convertedNumber = _converter.ConvertDigit(2);
            Assert.Equal("II", convertedNumber);
        }

        [Fact]
        public void GivenNumber3_WhenConvert_ShouldBeIII()
        {
            var convertedNumber = _converter.ConvertDigit(3);
            Assert.Equal("III", convertedNumber);
        }

        [Fact]
        public void GivenNumber4_WhenConvert_ShouldBeIV()
        {
            var convertedNumber = _converter.ConvertDigit(4);
            Assert.Equal("IV", convertedNumber);
        }

        [Fact]
        public void GivenNumber5_WhenConvert_ShouldBeV()
        {
            var convertedNumber = _converter.ConvertDigit(5);
            Assert.Equal("V", convertedNumber);
        }

        [Fact]
        public void GivenNumber6_WhenConvert_ShouldBeVI()
        {
            var convertedNumber = _converter.ConvertDigit(6);
            Assert.Equal("VI", convertedNumber);
        }

        [Fact]
        public void GivenNumber7_WhenConvert_ShouldBeVII()
        {
            var convertedNumber = _converter.ConvertDigit(7);
            Assert.Equal("VII", convertedNumber);
        }

        [Fact]
        public void GivenNumber8_WhenConvert_ShouldBeVIII()
        {
            var convertedNumber = _converter.ConvertDigit(8);
            Assert.Equal("VIII", convertedNumber);
        }


        [Fact]
        public void GivenNumber9_WhenConvert_ShouldBeIX()
        {
            var convertedNumber = _converter.ConvertDigit(9);
            Assert.Equal("IX", convertedNumber);
        }

        [Fact]
        public void GivenNumber10_WhenConvert_ShouldBeX()
        {
            var convertedNumber = _converter.ConvertDigit(10);
            Assert.Equal("X", convertedNumber);
        }

        [Fact]
        public void GivenNumber48_WhenConvert_ShouldBeXXXXVIII()
        {
            var convertedNumber = _converter.ConvertDigit(48);
            Assert.Equal("XXXXVIII", convertedNumber);
        }
    }
}
