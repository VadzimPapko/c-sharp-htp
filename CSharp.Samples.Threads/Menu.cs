using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CSharp.Samples.Threads
{

    internal class SuchiResponse 
    {
        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("data")]
        public Data Data { get; set; }
    }

    internal class Data 
    {
        [JsonPropertyName("dishMenus")]
        public List<dishMenus> Menus { get; set; }
    }


    internal class dishMenus
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }
    }
}
