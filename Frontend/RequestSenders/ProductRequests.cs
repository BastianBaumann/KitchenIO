using ClassLibrary.Objects;
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
    public class ProductRequests
    {

        public async Task<List<ProductRef>> PullProductRefs()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://localhost:7135/API/GetAllProducts";

                try
                {

                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();


                    string responseBody = await response.Content.ReadAsStringAsync();


                    List<ProductRef> answer = JsonConvert.DeserializeObject<List<ProductRef>>(responseBody);

                    return answer;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    return new List<ProductRef>();
                }
                catch (JsonException e)
                {
                    Console.WriteLine("\nJson Exception Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    return new List<ProductRef>();
                }
            }
        }

        public async Task<string> PushProductRef(ProductRef product)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://localhost:7135/API/CreateProduct";
                try
                {
                    string jsonProduct = JsonConvert.SerializeObject(product);

                    StringContent content = new StringContent(jsonProduct, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                    string answer = JsonConvert.DeserializeObject<string>(responseBody);

                    return answer;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    return null;
                }
                catch (JsonException e)
                {
                    Console.WriteLine("\nJson Exception Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    return null;
                }
            }
        }

        public async Task<ProductRef> GetProductRefByBarcode(string barcode)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"https://localhost:7135/API/GetProductByBarcode?barcode={barcode}";

                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                    ProductRef answer = JsonConvert.DeserializeObject<ProductRef>(responseBody);

                    return answer;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    return null; 
                }
                catch (JsonException e)
                {
                    Console.WriteLine("\nJson Exception Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    return null;
                }
            }
        }
        
    }
}
