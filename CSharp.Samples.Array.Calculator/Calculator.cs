using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Samples.Array.Calculator
{
    static class Calculator
    {
        static int _result;
        static int[] _results = new int[5];

        static int _operationNumber;


        public static void Sum(int num1, int num2)
        {
            _result = num1 + num2;
            SaveResult();
            _operationNumber++;
            Console.WriteLine(num1 + " + " + num2 + " = " + _result);
        }

        public static void Minus()
        {
            int numberA = 500;
            int numberB = 300;

            Console.WriteLine(numberA - numberB);
        }

        static void SaveResult()
        {
            _results[_operationNumber] = _result;
        }

        public static void ShowHistory()
        {
            Console.WriteLine("Your Calculator History:");

            for (int i = 1; i <= _results.Length; i++)
            {
                Console.WriteLine(i + ": " + _results[i - 1]);   //fisrt time use _results[i] -> then [i-1]
            }
        }
    }
}
