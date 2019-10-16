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
        [InlineData("1,5000", 5001)]
        [InlineData("4,-3", 1)]
        [InlineData("", 0)]
        [InlineData(null, 0)]
        [InlineData("5,tytyt", 5)]
        public void CalculateInput_CanAddTwoNumbers(string numbers, int expected)
        {
            int actual = Calculator.CalculateInput(numbers);

            Assert.Equal(expected, actual);
        }
    }
}
