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
                string url = $"https://localhost:7135/API/GetRecipes/{food}/{Allergies}";

                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                    List<Recipe> answer = JsonConvert.DeserializeObject<List<Recipe>>(responseBody);

                    return answer;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    return new List<Recipe>(); 
                }
                catch (JsonException e)
                {
                    Console.WriteLine("\nJson Exception Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    return new List<Recipe>();
                }
            }
        }
    }
}
