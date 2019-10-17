using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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
                if (int.TryParse(str, out int num) && num <= 1000)
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
            List<string> separators = new List<string> { ",", "\n" };
            string numbersRegion = input;

            // Check for delimiter region
            if (input.StartsWith("//") && input.IndexOf("\n") >= 3)
            {
                int newlineIndex = input.IndexOf("\n");

                // Get delimiter region
                string delimiterRegion = input.Substring(2, newlineIndex - 2);

                // Get numbers region
                numbersRegion = input.Substring(newlineIndex + 1);

                if (delimiterRegion.Length == 1)
                {
                    separators.Add(delimiterRegion);
                }
                else
                {
                    // Find all delimiters within square brackets []
                    var delimiterMatches = Regex.Matches(delimiterRegion, @"\[(.*?)\]")
                        .Cast<Match>()
                        .Select(m => new
                        {
                            delimiter = m.Groups[1].Value
                        })
                        .ToList();

                    // Add only first custom delimiter
                    separators.Add(delimiterMatches.First().delimiter);
                }
            }

            string[] output = numbersRegion.Split(separators.ToArray(), StringSplitOptions.RemoveEmptyEntries);
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
