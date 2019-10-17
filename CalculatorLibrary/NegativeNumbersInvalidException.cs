using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorLibrary
{
    public class NegativeNumbersInvalidException : Exception
    {
        public NegativeNumbersInvalidException(IEnumerable<int> numbers)
            : base($"Numbers cannot be negative: {String.Join(", ", numbers)}")
        {
        }
    }
}
