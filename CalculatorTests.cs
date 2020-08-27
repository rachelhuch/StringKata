using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StringCalculatorBlank
{
    public class CalculatorTests
    {
        Calculator calculator;
        public CalculatorTests()
        {
            calculator = new Calculator(/*dummy*/ new Mock<ILogger>().Object, new Mock<IWebService>().Object);
        }
        [Fact]
        public void EmptyStringReturnsZero()
        {
            int answer = calculator.Add("");

            Assert.Equal(0, answer);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("99", 99)]
        public void SingleDigits(string numbers, int expected)
           {

            int answer = calculator.Add(numbers);

            Assert.Equal(expected, answer);

        }

        [Theory]
        [InlineData("1,2",3)]
        [InlineData("99,1", 100)]
        public void TwoNumbers(string numbers, int expected)
        {

            int answer = calculator.Add(numbers);

            Assert.Equal(expected, answer);

        }

        [Theory]
        [InlineData("1,2,3", 6)]
        public void Arbitrary(string numbers, int expected)
        {

            int answer = calculator.Add(numbers);

            Assert.Equal(expected, answer);

        }
    }
}
