using ClassLibrary.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.RequestSenders
{
    public class KitchenRequests
    {
        public async Task<Kitchen> GetKitchenById(Guid KitchenId)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"https://localhost:7135/Bindings/GetKitcheById/{KitchenId}";

                try
                {

                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();


                    string responseBody = await response.Content.ReadAsStringAsync();


                    Kitchen answer = JsonConvert.DeserializeObject<Kitchen>(responseBody);

                    return answer;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    return new Kitchen();
                }
                catch (JsonException e)
                {
                    Console.WriteLine("\nJson Exception Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    return new Kitchen();
                }
            }
        }
        public async Task<List<User>> GetUserByKitchen(Guid KitchenId)
        {
            // GetUsersByKitchen /{ KitchenId}
            using (HttpClient client = new HttpClient())
            {
                string url = $"https://localhost:7135/Bindings/GetUsersByKitchen/{KitchenId}";

                try
                {

                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();


                    string responseBody = await response.Content.ReadAsStringAsync();


                    List<User> answer = JsonConvert.DeserializeObject<List<User>>(responseBody);

                    return answer;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    return new List<User>();
                }
                catch (JsonException e)
                {
                    Console.WriteLine("\nJson Exception Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    return new List<User>();
                }
            }
        }
        public async Task<List<ClassLibrary.Objects.Binding>> getBindingsByUser(Guid UserId)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"https://localhost:7135/Bindings/GetBindingsByUser/{UserId}";

                try
                {

                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();


                    string responseBody = await response.Content.ReadAsStringAsync();


                    List<ClassLibrary.Objects.Binding> answer = JsonConvert.DeserializeObject<List<ClassLibrary.Objects.Binding>>(responseBody);

                    return answer;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    return new List<Binding>();
                }
                catch (JsonException e)
                {
                    Console.WriteLine("\nJson Exception Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    return new List<Binding>();
                }
            }
        }
        public async Task<string> CreateKitchen(Kitchen newKitchen)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://localhost:7135/Bindings/CreateKitchen";
                try
                {
                    // Serialisiere das Produktobjekt in einen JSON-String
                    string jsonProduct = JsonConvert.SerializeObject(newKitchen);

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
        public async Task<string> CreateBind(ClassLibrary.Objects.Binding newBind)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://localhost:7135/Bindings/BindKitchen";
                try
                {
                    // Serialisiere das Produktobjekt in einen JSON-String
                    string jsonProduct = JsonConvert.SerializeObject(newBind);

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
    }
}
