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

        public async Task<ProductRef> GetProductRefByBarcode(string barcode)
        {
            using (HttpClient client = new HttpClient())
            {
                // URL mit Barcode als Query-Parameter
                string url = $"https://localhost:7135/API/GetProductByBarcode?barcode={barcode}";

                try
                {
                    // Sende die GET-Anfrage
                    HttpResponseMessage response = await client.GetAsync(url);

                    // Sicherstellen, dass der Statuscode Erfolg signalisiert
                    response.EnsureSuccessStatusCode();

                    // Antwortinhalt als String lesen
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Deserialisieren der JSON-Antwort in ein ProductRef-Objekt
                    ProductRef answer = JsonConvert.DeserializeObject<ProductRef>(responseBody);

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
