using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculatorLibrary
{
    public static class Calculator
    {
        public static int CalculateInput(string input)
        {
            int output = 0;

            // Convert empty input to 0
            if (String.IsNullOrEmpty(input))
            {
                return 0;
            }

            // Split array by delimiters
            string[] formattedInput = FormatInput(input);

            // Convert to integer array
            IEnumerable<int> integers = ToIntArray(formattedInput);

            // Check for negative numbers
            ValidateNumbers(integers);

            output = Add(integers);

            return output;
        }

        public static int Add(IEnumerable<int> numbers)
        {
            return numbers.Sum();
        }

        public static IEnumerable<int> ToIntArray(string[] numbers)
        {
            List<int> output = new List<int>();
            foreach (string str in numbers)
            {
                if (int.TryParse(str, out int num))
                {
                    output.Add(num);
                }
                else
                {
                    output.Add(0);
                }
            }
            return output;
        }

        public static string[] FormatInput(string input)
        {
            string[] separators = { ",", "\n", "\\n" };
            string[] output = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            return output;
        }

        public static void ValidateNumbers(IEnumerable<int> numbers)
        {
            // Extract negative numbers
            IEnumerable<int> negativeNumbers = numbers.Where(i => i < 0);

            if (negativeNumbers.Any())
            {
                throw new NegativeNumbersInvalidException(negativeNumbers);
            }
            foreach (var neg in negativeNumbers)
            {
                Console.WriteLine(neg);
            }
        }

    }

}
