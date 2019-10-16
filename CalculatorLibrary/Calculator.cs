using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculatorLibrary
{
    public static class Calculator
    {
        public static int CalculateInput(string input)
        {
            int result = 0;

            // Validate input
            if (String.IsNullOrEmpty(input))
            {
                return 0;
            }

            string[] numbers = input.Split(",", StringSplitOptions.RemoveEmptyEntries);

            IEnumerable<int> integers = ToIntArray(numbers);

            result = Add(integers);

            return result;
        }

        public static int Add(IEnumerable<int> numbers)
        {
            return numbers.Sum();
        }

        public static IEnumerable<int> ToIntArray(string[] numbers)
        {
            List<int> list = new List<int>();
            foreach (string str in numbers)
            {
                int num;
                if (int.TryParse(str, out num))
                {
                    list.Add(num);
                }
                else
                {
                    list.Add(0);
                }
            }
            return list;
        }

    }

}
