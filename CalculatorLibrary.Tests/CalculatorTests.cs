using System;
using System.Collections.Generic;
using System.Text;
using CalculatorLibrary;
using Xunit;

namespace CalculatorLibrary.Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData("20", 20)]
        [InlineData("1,500", 501)]
        [InlineData("", 0)]
        [InlineData(null, 0)]
        [InlineData("5,tytyt", 5)]
        public void CalculateInput_CanAddTwoNumbers(string input, int expected)
        {
            // Act
            int actual = Calculator.CalculateInput(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1,2,3,4,5,6,7,8,9,10,11,12", 78)]
        [InlineData("10,20,30", 60)]
        public void CalculateInput_CanAddMoreThanTwoNumbers(string input, int expected)
        {
            // Act
            int actual = Calculator.CalculateInput(input);

            // Asert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1\n2,3", 6)]
        [InlineData("2\n5,4\n8", 19)]
        public void CalculateInput_CanAddWithNewlineDelimiter(string input, int expected)
        {
            // Act
            int actual = Calculator.CalculateInput(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("-1,-2")]
        public void CalculateInput_NegativeNumbersThrowException(string input)
        {
            // Act
            Exception exception = Assert.Throws<NegativeNumbersInvalidException>(() => Calculator.CalculateInput(input));

            // Assert
            Assert.Equal("Numbers cannot be negative: -1, -2", exception.Message);
        }

        [Theory]
        [InlineData("2,1001,6", 8)]
        [InlineData("1,5000", 1)]
        public void CalculateInput_AddIgnoresNumbersOver1000(string input, int expected)
        {
            // Act
            int actual = Calculator.CalculateInput(input);

            // Assert
            Assert.Equal(expected, actual);
        }

    }
}
