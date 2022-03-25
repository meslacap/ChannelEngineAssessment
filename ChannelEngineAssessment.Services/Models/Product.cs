using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelEngineAssessment.Services.Models
{
    public class ProductContent
    {
        [JsonProperty("Content")]
        public IEnumerable<Product> Product { get; set; }
    }

    public class Product
    {
        [JsonProperty("IsActive")]
        public bool IsActive { get; set; }

        [JsonProperty("ExtraData")]
        public IEnumerable<ExtraData> ExtraData { get; set; }

        [JsonProperty("ParentMerchantProductNo")]
        public string ParentMerchantProductNo { get; set; }

        [JsonProperty("ParentMerchantProductNo2")]
        public string ParentMerchantProductNo2 { get; set; }        

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Brand")]
        public string Brand { get; set; }

        [JsonProperty("Size")]
        public string Size { get; set; }

        [JsonProperty("Color")]
        public string Color { get; set; }

        [JsonProperty("Ean")]
        public string Ean { get; set; }

        [JsonProperty("MerchantProductNo")]
        public string MerchantProductNo { get; set; }

        [JsonProperty("Stock")]
        public int Stock { get; set; }

        [JsonProperty("Price")]
        public double Price { get; set; }

        [JsonProperty("MSRP")]
        public double MSRP { get; set; }

        [JsonProperty("PurchasePrice")]
        public double PurchasePrice { get; set; }

        [JsonProperty("VatRateType")]
        public string VatRateType { get; set; }

        [JsonProperty("ShippingCost")]
        public double ShippingCost { get; set; }

        [JsonProperty("ShippingTime")]
        public string ShippingTime { get; set; }

        [JsonProperty("Url")]
        public string Url { get; set; }

        [JsonProperty("ImageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty("ExtraImageUrl1")]
        public string ExtraImageUrl1 { get; set; }

        [JsonProperty("ExtraImageUrl2")]
        public string ExtraImageUrl2 { get; set; }

        [JsonProperty("ExtraImageUrl3")]
        public string ExtraImageUrl3 { get; set; }

        [JsonProperty("ExtraImageUrl4")]
        public string ExtraImageUrl4 { get; set; }

        [JsonProperty("ExtraImageUrl5")]
        public string ExtraImageUrl5 { get; set; }

        [JsonProperty("ExtraImageUrl6")]
        public string ExtraImageUrl6 { get; set; }

        [JsonProperty("ExtraImageUrl7")]
        public string ExtraImageUrl7 { get; set; }

        [JsonProperty("ExtraImageUrl8")]
        public string ExtraImageUrl8 { get; set; }

        [JsonProperty("ExtraImageUrl9")]
        public string ExtraImageUrl9 { get; set; }

        [JsonProperty("CategoryTrail")]
        public string CategoryTrail { get; set; }
    }

    public class ExtraData
    {
        [JsonProperty("Key")]
        public string Key { get; set; }

        [JsonProperty("Value")]
        public string Value { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("IsPublic")]
        public bool IsPublic { get; set; }
    }
}
