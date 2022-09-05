using System;
using System.IO;

namespace CSharp.Samples_01
{
    /// <summary>
    /// C# basic. Sample 1- Convert Image to Binary.
    /// </summary>
    class Program
    {
        private const string RootPath = @"C:\!academy\Demka\";
        private const string ImagePath = RootPath + "selfie.png";
        private const string FilePath = RootPath + "image.txt";
        private const string NewImagePath = RootPath + "new.png";

        static void Main(string[] args)
        {
            #region Convert Image To Binary

            //ConvertImage2Binary();

            #endregion

            #region Convert Binary Text to Image

            ReadBinary2Image();
            
            #endregion

            Console.ReadKey();
        }

        private static void ConvertImage2Binary()
        {
            byte[] imageBytes = File.ReadAllBytes(ImagePath);
            var counter = 0;

            using (StreamWriter streamWriter = new StreamWriter(FilePath, true)) 
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
            StreamReader textReader = new StreamReader(FilePath, true);
            string textReaderResult = textReader.ReadToEnd();
            textReader.Dispose();

            string[] arrayOfTextResult = textReaderResult.Split(' ');

            byte[] imageBytes = new byte[arrayOfTextResult.Length - 1];
            for (int i = 0; i < arrayOfTextResult.Length -1 ; i++)
            {
                var binary = Convert.ToByte(arrayOfTextResult[i], 2);
                imageBytes[i] = binary;
            }

            File.WriteAllBytes(NewImagePath, imageBytes);

            Console.WriteLine("Done");
        } 
    }
}
