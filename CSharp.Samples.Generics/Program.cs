using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace CSharp.Samples.Generics
{
    class Program
    {
        const string _pathToDumpFolder = @"C:\!academy\Demo";
        static void Main(string[] args)
        {
            //With int
            //CustomStack customStack = new CustomStack();
            //customStack.Push(19);
            //customStack.Push(25);
            //int item = customStack.Pop();

            //With object
            //CustomStack customStack = new CustomStack();
            //customStack.Push(19);
            //customStack.Push(25);
            //customStack.Push(DateTime.Now);
            //int item = (int)customStack.Pop();

            CustomStack<int> customStack = new CustomStack<int>();
            customStack.Push(19);
            customStack.Push(25);
            //customStack.Push(DateTime.Now);
            int item = customStack.Pop();

            Moto<int, string> moto = new Moto<int, string>();

            int number = moto.GetVin("99", 99);

            Dictionary<int, DateTime> pairs = new Dictionary<int, DateTime>();
            pairs.Add(99, DateTime.Now);
            //pairs.Add(99, DateTime.UtcNow);
            pairs[100] = DateTime.Today;
            pairs.TryGetValue(99, out DateTime value);
            var result = value;

            Hashtable table = new Hashtable();
            table.Add(99, DateTime.Now);
            //table.Add(99, DateTime.UtcNow);

            //Dictionary real Sample
            var fileNames = GetFileNames();
            var mapFiles = fileNames.Where(x => x.EndsWith("_map.json")).ToList();
            var dictionary = GetMappedStructure(mapFiles);
        }

        private static Dictionary<string, List<string>> GetMappedStructure(IEnumerable<string> fileNames)
        {
            var result = new Dictionary<string, List<string>>();

            foreach (var fileName in fileNames)
            {
                var fileText = ReadFile(fileName);
                var shortModel = JsonSerializer.Deserialize<ExhibitorDataModel>(fileText);
                var dataSynqManufacturerID = shortModel.DataSynqManufacturerID;
                var exhibitorIds = shortModel.ExhibitorId;

                if (exhibitorIds == null || !exhibitorIds.Any())
                {
                    continue;
                }

                foreach (var exhibitorId in exhibitorIds)
                {
                    if (!result.ContainsKey(exhibitorId))
                    {
                        result.Add(exhibitorId, new List<string>());
                    }

                    result[exhibitorId].Add(dataSynqManufacturerID);
                }
            }

            return result;
        }

        static IList<string> GetFileNames()
        {
            return Directory.GetFiles(_pathToDumpFolder).Select(Path.GetFileName).ToList();
        }

        static string ReadFile(string key)
        {
            if (!key.EndsWith(".json"))
            {
                key += ".json";
            }

            return File.ReadAllText(Path.Combine(_pathToDumpFolder, key));
        }
    }

    public class ExhibitorDataModel
    {
        public string[] ExhibitorId { get; set; }
        public string DataSynqManufacturerID { get; set; }
    }
}
