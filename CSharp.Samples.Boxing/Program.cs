using System;
using System.Diagnostics;

namespace CSharp.Samples.Boxing
{
    class Program
    {
        static void Main(string[] args)
        {
            FillArrayWithoutBoxing();
            FillArrayWithBoxing();
        }

        private static void FillArrayWithoutBoxing()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            decimal[] decimalArray = new decimal[1_000_000];
            for (int i = 0; i < decimalArray.Length; i++)
            {
                decimalArray[i] = new decimal(i);
            }

            stopwatch.Stop();

            Console.WriteLine($"Completed for {stopwatch.ElapsedMilliseconds} ms");
        }

        private static void FillArrayWithBoxing()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            object[] objArray = new object[1_000_000];
            for (int i = 0; i < objArray.Length; i++)
            {
                objArray[i] = new decimal(i);
            }

            stopwatch.Stop();

            Console.WriteLine($"Completed for {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
