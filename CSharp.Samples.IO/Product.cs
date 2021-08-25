using Newtonsoft.Json;
using System.Collections.Generic;

namespace CSharp.Samples.IO
{
    public class Product
    {
        [JsonProperty("repo")]
        public string Repo { get; set; }
        public Dictionary<string, long[]> ProductCategoryIDs { get; set; }
        public string ProductSKU { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductState { get; set; }
        public string SortOrder { get; set; }
        public bool IsDeleted { get; set; }
    }
}