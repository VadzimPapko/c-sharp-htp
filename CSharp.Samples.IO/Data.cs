using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Samples.IO
{
    class Data
    {
        public string[] ExhibitorId { get; set; }
        public string ManufacturerState { get; set; }
        public string ManufacturerVendorName { get; set; }
        public string DefaultDescription { get; set; }
        public string DataSynqManufacturerID { get; set; }
        public List<string> SubscribedTo { get; set; }
        public List<string> PublishedTo { get; set; }

        [JsonProperty("TestChannels")]
        public IList<string> ChannelSiteCodes { get; set; }
        public string ShopZioURL { get; set; }
        public IList<Product> Products { get; set; }
    }
}
