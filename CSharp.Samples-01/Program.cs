using System;
using System.IO;

namespace CSharp.Samples_01
{
    /// <summary>
    /// C# basic. Sample 1- Convert Image to Binary.
    /// </summary>
    class Program
    {
        private const string imageRootPath = @"C:\Users\vadim\Downloads\c#.png";

        static void Main(string[] args)
        {
            #region Convert Image To Binary

            ConvertImage2Binary();

            #endregion

            Console.ReadKey();
        }
        private static void ConvertImage2Binary()
        {
            byte[] imageBytes = File.ReadAllBytes(imageRootPath);
            var counter = 0;
            foreach (var item in imageBytes)
            {
                counter++;
                Console.Write(Int32.Parse(Convert.ToString(item, 2)).ToString("0000 0000 "));

                if (counter > 9)
                {
                    Console.WriteLine();
                    counter = 0;
                }
            }
        }
    }
}
