using ClassLibrary.Objects;
using Newtonsoft.Json;
using System.Net.Http;
using System;
using System.Threading.Tasks;

namespace KitchenAPI.Handlers
{
    public class RecipeHandler
    {
        public async Task<List<Recipe>> GetAllRecipes(string query)
        {

            string api_key = "GDhZ4/8euUTcTtCOKOjlKA==UkjauVzTI4jMJJ8H";

            List<Recipe> TotalList = new List<Recipe>();


            using (HttpClient client = new HttpClient())
            {
                var offset = 0;
                int totalList = 0;
                int maxList = 100;


                client.DefaultRequestHeaders.Add("X-Api-Key", api_key);

                while(totalList < maxList)
                {
                    string url = $"https://api.api-ninjas.com/v1/recipe?query={Uri.EscapeDataString(query)}&offset={offset}";
                    try
                    {

                        HttpResponseMessage response = await client.GetAsync(url);
                        response.EnsureSuccessStatusCode();


                        string responseBody = await response.Content.ReadAsStringAsync();


                        List<Recipe> answer = JsonConvert.DeserializeObject<List<Recipe>>(responseBody);

                        if (answer.Count > 0)
                        {
                            foreach (Recipe answerItem in answer)
                            {
                                TotalList.Add(answerItem);
                            }
                            offset = offset + 10;
                        }
                        else if (answer.Count == 0)
                        {
                            break;
                        }


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

                    if(offset == maxList)
                    {
                        break;
                    }
                }
                return TotalList;
            }
        }
    }
}
