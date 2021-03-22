using System;
using System.IO;

namespace CSharp.Samples_01
{
    /// <summary>
    /// C# basic. Sample 1- Convert Image to Binary.
    /// </summary>
    class Program
    {
        private const string imageRootPath = @"C:\!academy\selfie.png";

        static void Main(string[] args)
        {
            #region Convert Image To Binary

            ConvertImage2Binary();

            #endregion

            #region Convert Binary Text to Image

            ReadBinary2Image();
            
            #endregion

            Console.ReadKey();
        }

        private static void ConvertImage2Binary()
        {
            byte[] imageBytes = File.ReadAllBytes(imageRootPath);
            var counter = 0;

            using (StreamWriter streamWriter = new StreamWriter(@"C:\Temp\image.txt", true)) 
            {
                foreach (var item in imageBytes)
                {
                    counter++;
                    var @byte = Int32.Parse(Convert.ToString(item, 2));
                    streamWriter.Write(@byte.ToString("00000000 "));
                    Console.Write(@byte.ToString("0000 0000 "));

                    if (counter > 9)
                    {
                        Console.WriteLine();
                        counter = 0;
                    }
                }
            }
        }

        private static void ReadBinary2Image() 
        {
            StreamReader textReader = new StreamReader(@"C:\Temp\image.txt", true);
            string textReaderResult = textReader.ReadToEnd();
            textReader.Dispose();

            string[] arrayOfTextResult = textReaderResult.Split(' ');

            byte[] imageBytes = new byte[arrayOfTextResult.Length - 1];
            for (int i = 0; i < arrayOfTextResult.Length -1 ; i++)
            {
                var binary = Convert.ToByte(arrayOfTextResult[i], 2);
                imageBytes[i] = binary;
            }

            File.WriteAllBytes(@"C:\Temp\image.jpg", imageBytes);
        } 
    }
}
