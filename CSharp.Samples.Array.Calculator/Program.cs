using System;

namespace CSharp.Samples.Array.Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;

            while (counter != 5)
            {
                Console.WriteLine("Input first number: ");
                int number1 = Convert.ToInt32(Console.ReadLine()); counte

                Console.WriteLine("Input second number: ");
                int number2 = Convert.ToInt32(Console.ReadLine());

                Calculator.Sum(number1, number2);
                counter++;

                Console.WriteLine();
            }

            Calculator.ShowHistory();
        }
    }
}
