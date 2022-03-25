using ChannelEngineAssessment.Services.Interfaces;
using ChannelEngineAssessment.Services.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ChannelEngineAssessment.Services.Services
{
    public class OrdersService : IOrderService
    {
        private const string baseUrl = "https://api-dev.channelengine.net/api/v2/";
        private const string apiKey = "apikey=541b989ef78ccb1bad630ea5b85c6ebff9ca3322";
        private Content content = new();
        private ProductContent productContent = new();

        /// <summary>
        /// Get All Orders from ChannelEngine API
        /// </summary>
        /// <returns></returns>
        public async Task<List<Order>> FetchAllOrdersAsync()
        {
            using HttpClient client = new();

            try
            {
                var response = await client.GetAsync(baseUrl + "orders?statuses=IN_PROGRESS&" + apiKey);

                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    content = JsonConvert.DeserializeObject<Content>(json);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }                        

            return content.Orders.ToList();
        }

        /// <summary>
        /// Update Stock by Merchant Product Number
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> IsProductStockUpdated(List<Product> products)
        {
            using HttpClient client = new();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            products.FirstOrDefault().Stock = 25;

            var json = JsonConvert.SerializeObject(products);

            try
            {
                var response = await client.PostAsync($"{baseUrl}products?ignoreStock=false&{apiKey}", new StringContent(json, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<Product>(res);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return true;
        }

        /// <summary>
        /// Get Product by Merchat Product Number
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public async Task<List<Product>> GetProduct(Lines line)
        {
            using HttpClient client = new();

            try
            {
                var response = await client.GetAsync($"{baseUrl}products?search={line.MerchantProductNo}&{apiKey}");

                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    productContent = JsonConvert.DeserializeObject<ProductContent>(res);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return productContent.Product.ToList();
        }
    }
}
