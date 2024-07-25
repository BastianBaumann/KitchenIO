using ClassLibrary.Objects;
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
    public class RecipeRequests
    {
        public async Task<List<Recipe>> getRecipeWithAllergies(string food, string Allergies)
        {
            using (HttpClient client = new HttpClient())
            {
                // URL mit Barcode als Query-Parameter
                string url = $"https://localhost:7135/API/GetRecipes/{food}/{Allergies}";

                try
                {
                    // Sende die GET-Anfrage
                    HttpResponseMessage response = await client.GetAsync(url);

                    // Sicherstellen, dass der Statuscode Erfolg signalisiert
                    response.EnsureSuccessStatusCode();

                    // Antwortinhalt als String lesen
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Deserialisieren der JSON-Antwort in ein ProductRef-Objekt
                    List<Recipe> answer = JsonConvert.DeserializeObject<List<Recipe>>(responseBody);

                    return answer;
                }
                catch (HttpRequestException e)
                {
                    // Fehlerbehandlung bei HTTP-Anfragen
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    return new List<Recipe>(); // Rückgabe von null statt einer leeren Instanz, um anzuzeigen, dass ein Fehler aufgetreten ist
                }
                catch (JsonException e)
                {
                    // Fehlerbehandlung bei JSON-Verarbeitung
                    Console.WriteLine("\nJson Exception Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    return new List<Recipe>(); // Rückgabe von null statt einer leeren Instanz
                }
            }
        }
    }
}
