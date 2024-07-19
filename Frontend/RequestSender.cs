using KitchenIO.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Frontend
{
    public class TestRequests
    {
        public async Task<Product> TestProductCreation()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://localhost:7135/API/GetTest"; 

                try
                {

                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();


                    string responseBody = await response.Content.ReadAsStringAsync();


                    Product product = JsonConvert.DeserializeObject<Product>(responseBody);

                    return product;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    return new Product();
                }
                catch (JsonException e)
                {
                    Console.WriteLine("\nJson Exception Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    return new Product();
                }
            }
        }
    }
}
