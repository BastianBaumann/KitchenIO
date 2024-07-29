using ClassLibrary.Objects;
using Microsoft.VisualBasic.ApplicationServices;
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
        public async Task<List<ClassLibrary.Objects.User>> GetUserByKitchen(Guid KitchenId)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"https://localhost:7135/Bindings/GetUsersByKitchen/{KitchenId}";

                try
                {

                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();


                    string responseBody = await response.Content.ReadAsStringAsync();


                    List<ClassLibrary.Objects.User> answer = JsonConvert.DeserializeObject<List<ClassLibrary.Objects.User>>(responseBody);

                    return answer;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    return new List<ClassLibrary.Objects.User>();
                }
                catch (JsonException e)
                {
                    Console.WriteLine("\nJson Exception Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    return new List<ClassLibrary.Objects.User>();
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
                    string jsonProduct = JsonConvert.SerializeObject(newKitchen);

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
        public async Task<string> CreateBind(ClassLibrary.Objects.Binding newBind)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://localhost:7135/Bindings/BindKitchen";
                try
                {
                    string jsonProduct = JsonConvert.SerializeObject(newBind);

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
        public async Task<string> DeleteBind(Guid UserId, Guid KitchenId)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"https://localhost:7135/Bindings/DeleteBindUsery/{UserId}/{KitchenId}";

                try
                {

                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();


                    string responseBody = await response.Content.ReadAsStringAsync();

                    string answer = JsonConvert.DeserializeObject<string>(responseBody);

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
