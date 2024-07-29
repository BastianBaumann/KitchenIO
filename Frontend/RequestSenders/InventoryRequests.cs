using ClassLibrary.Objects;
using KitchenIO.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.RequestSenders
{
    public class InventoryRequests
    {
        public async Task<string> AddToInventorie(Product product)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://localhost:7135/API/AddProduct";
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

        public async Task<List<Product>> GetInventory()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://localhost:7135/API/GetInventory";

                try
                {

                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();


                    string responseBody = await response.Content.ReadAsStringAsync();


                    List<Product> answer = JsonConvert.DeserializeObject<List<Product>>(responseBody);

                    return answer;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    return new List<Product>();
                }
                catch (JsonException e)
                {
                    Console.WriteLine("\nJson Exception Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    return new List<Product>();
                }
            }
        }

        public async Task<List<Product>> GetInventoryByOwner(Guid Owner)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"https://localhost:7135/API/GetByOwnerInventory/{Owner}";

                try
                {

                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();


                    string responseBody = await response.Content.ReadAsStringAsync();


                    List<Product> answer = JsonConvert.DeserializeObject<List<Product>>(responseBody);

                    return answer;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    return new List<Product>();
                }
                catch (JsonException e)
                {
                    Console.WriteLine("\nJson Exception Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    return new List<Product>();
                }
            }
        }

        public async Task<List<Product>> VerifyFood(Guid Owner)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"https://localhost:7135/API/ValidateFoody/{Owner}";

                try
                {

                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();


                    string responseBody = await response.Content.ReadAsStringAsync();


                    List<Product> answer = JsonConvert.DeserializeObject<List<Product>>(responseBody);

                    return answer;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    return new List<Product>();
                }
                catch (JsonException e)
                {
                    Console.WriteLine("\nJson Exception Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    return new List<Product>();
                }
            }
        }
        public async Task<string> updateItem(Product productToUpdate)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://localhost:7135/API/UpdateInventory";
                try
                {
                    string jsonProduct = JsonConvert.SerializeObject(productToUpdate);

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
        public async Task<string> deleteItem(Guid productToDelete)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"https://localhost:7135/API/DeleteInventory/{productToDelete}";

                try
                {

                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();


                    string responseBody = await response.Content.ReadAsStringAsync();


                    string answer = JsonConvert.DeserializeObject<string> (responseBody);

                    return answer;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    return e.Message;
                }
                catch (JsonException e)
                {
                    Console.WriteLine("\nJson Exception Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    return e.Message;
                }
            }
        }
    }
}
