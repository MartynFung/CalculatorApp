﻿using System;
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
        public void CalculateInput_CanAddTwoNumbers(string input, int expected)
        {
            int actual = Calculator.CalculateInput(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1,2,3,-4", 2)]
        [InlineData("1,2,3,4,5,6,7,8,9,10,11,12", 78)]
        [InlineData("1\n2,3", 6)]
        [InlineData("2\n5,4\n8", 19)]
        public void CalculateInput_CanAddMoreThanTwoNumbers(string input, int expected)
        {
            int actual = Calculator.CalculateInput(input);

            Assert.Equal(expected, actual);
        }


    }
}
