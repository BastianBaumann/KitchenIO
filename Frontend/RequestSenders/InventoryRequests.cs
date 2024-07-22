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
                    // Serialisiere das Produktobjekt in einen JSON-String
                    string jsonProduct = JsonConvert.SerializeObject(product);

                    // Erstelle den HttpContent mit dem JSON-String
                    StringContent content = new StringContent(jsonProduct, Encoding.UTF8, "application/json");

                    // Sende die POST-Anfrage
                    HttpResponseMessage response = await client.PostAsync(url, content);
                    response.EnsureSuccessStatusCode();

                    // Lese die Antwort als String
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Deserialisiere die Antwort in ein Product-Objekt
                    string answer = JsonConvert.DeserializeObject<string>(responseBody);

                    return answer;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    return null; // oder eine andere geeignete Rückgabewert, falls erforderlich
                }
                catch (JsonException e)
                {
                    Console.WriteLine("\nJson Exception Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    return null; // oder eine andere geeignete Rückgabewert, falls erforderlich
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

    }
}
