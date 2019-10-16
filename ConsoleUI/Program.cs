using CalculatorLibrary;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a series of numbers delimited by commas or newline characters :");

            string input = Console.ReadLine();

            try
            {
                int result = Calculator.CalculateInput(input);
                Console.WriteLine($"result: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
