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
    class UserRequests
    {
        public async Task<string> CreateUser(User newUser)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://localhost:7135/API/CreateProduct";
                try
                {
                    // Serialisiere das Produktobjekt in einen JSON-String
                    string jsonProduct = JsonConvert.SerializeObject(newUser);

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
        public async Task<User> Login(User user)
        {
            using (HttpClient client = new HttpClient())
            {
                // URL mit Barcode als Query-Parameter
                string url = $"https://localhost:7135/API/LoginUser";

                try
                {
                    // Sende die GET-Anfrage
                    HttpResponseMessage response = await client.GetAsync(url);

                    // Sicherstellen, dass der Statuscode Erfolg signalisiert
                    response.EnsureSuccessStatusCode();

                    // Antwortinhalt als String lesen
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Deserialisieren der JSON-Antwort in ein ProductRef-Objekt
                    User answer = JsonConvert.DeserializeObject<User>(responseBody);

                    return answer;
                }
                catch (HttpRequestException e)
                {
                    // Fehlerbehandlung bei HTTP-Anfragen
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    return null; // Rückgabe von null statt einer leeren Instanz, um anzuzeigen, dass ein Fehler aufgetreten ist
                }
                catch (JsonException e)
                {
                    // Fehlerbehandlung bei JSON-Verarbeitung
                    Console.WriteLine("\nJson Exception Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    return null; // Rückgabe von null statt einer leeren Instanz
                }
            }
        }
    }
}
