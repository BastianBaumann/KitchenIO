using ClassLibrary.Objects;
using KitchenIO.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace Frontend.RequestSenders
{
    class UserRequests
    {
        public async Task<string> PushUser(User newUser)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://localhost:7135/API/CreateUser";
                try
                {
                    string jsonUser = JsonConvert.SerializeObject(newUser);

                    StringContent content = new StringContent(jsonUser, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                    Console.WriteLine("Response: " + responseBody);

                    return responseBody;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    return "Error";
                }
                catch (JsonException e)
                {
                    Console.WriteLine("\nJson Exception Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    return "Error"; 
                }
            }
        }
        public async Task<Guid> Login(string username, string password)
        {
            using (HttpClient client = new HttpClient())
            {
                // URL mit Barcode als Query-Parameter
                string url = $"https://localhost:7135/API/LoginUser/{username}/{password}";

                try
                {
                    // Sende die GET-Anfrage
                    HttpResponseMessage response = await client.GetAsync(url);

                    // Sicherstellen, dass der Statuscode Erfolg signalisiert
                    response.EnsureSuccessStatusCode();

                    // Antwortinhalt als String lesen
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Deserialisieren der JSON-Antwort in ein ProductRef-Objekt
                    Guid answer = JsonConvert.DeserializeObject<Guid>(responseBody);

                    return answer;
                }
                catch (HttpRequestException e)
                {
                    // Fehlerbehandlung bei HTTP-Anfragen
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    return Guid.Empty; // Rückgabe von null statt einer leeren Instanz, um anzuzeigen, dass ein Fehler aufgetreten ist
                }
                catch (JsonException e)
                {
                    // Fehlerbehandlung bei JSON-Verarbeitung
                    Console.WriteLine("\nJson Exception Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    return Guid.Empty; // Rückgabe von null statt einer leeren Instanz
                }
            }
        }
        public async Task<Guid> getUserIdByName(string name)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"https://localhost:7135/API/GetUserByName/{name}";

                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                    User answer = JsonConvert.DeserializeObject<User>(responseBody);

                    return answer.Id;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    return Guid.Empty; 
                }
                catch (JsonException e)
                {
                    Console.WriteLine("\nJson Exception Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    return Guid.Empty; 
                }
            }
        }
    }
}
