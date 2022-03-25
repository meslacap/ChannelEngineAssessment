using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelEngineAssessment.Services.Models
{
    public class Content
    {
        [JsonProperty("Content")]
        public List<Order> Orders { get; set; }
    }

    public class Order
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("ChannelName")]
        public string ChannelName { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }

        [JsonProperty("Lines")]
        public List<Lines> Lines { get; set; }
    }

    public class Lines
    {
        [JsonProperty("Gtin")]
        public string GTIN { get; set; }

        [JsonProperty("Quantity")]
        public int Quantity { get; set; }

        [JsonProperty("MerchantProductNo")]
        public string MerchantProductNo { get; set; }
    }
}