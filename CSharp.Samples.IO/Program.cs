using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CSharp.Samples.IO
{
    class Program
    {
        const string _pathToDumpFolder = @"C:\!academy\Demo";

        static void Main(string[] args)
        {
            // Relative Path Sample
            //Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            //Console.WriteLine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
            
            //Relative Path Sample
            //var files = Directory.GetFiles("../../../Data");

            var files = GetFileNames();
            foreach (var file in files)
            {
                if (File.Exists(Path.Combine(_pathToDumpFolder, file)))
                {
                    string content = ReadFile(file);
                    Console.WriteLine(content);

                    try
                    {
                        Data data = JsonConvert.DeserializeObject<Data>(content);
                        //var json = JsonConvert.SerializeObject(data);
                        //WriteFile(json);
                    }
                    catch (JsonSerializationException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine(ex.StackTrace);
                    }
                    catch (JsonReaderException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine(ex.StackTrace);
                    }
                }
            }
        }

        static IList<string> GetFileNames()
        {
            return Directory.GetFiles(_pathToDumpFolder).Select(Path.GetFileName).ToList();
        }

        static string ReadFile(string fileName) 
        {
            return File.ReadAllText(Path.Combine(_pathToDumpFolder, fileName));
        }

        static void WriteFile(string text) 
        {
            File.WriteAllText(Path.Combine(_pathToDumpFolder, "new.json"), text);
        }
    }
}
