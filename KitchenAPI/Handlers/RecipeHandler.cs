using ClassLibrary.Objects;
using Newtonsoft.Json;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Drawing;

namespace KitchenAPI.Handlers
{
    public class RecipeHandler
    {
        public bool VerifyAllergy(string ingedients,string allergies)
        {
            List<string> GrainAllergents = new List<string>{ "Wheat", "Rye", "Barley", "Oats", "Corn", "Rice", "Millet", "Quinoa", "Amaranth" };
            List<string> DairyAllergents = new List<string> { "Cow's milk", "Goat's milk", "Sheep's milk", "Cheese, Yogurt", "Butter", "Cream", "milk" };
            List<string> EggsAllergents = new List<string> { "Chicken eggs"," Quail eggs", "Duck eggs", "eggs" };
            List<string> NutsAllergents = new List<string> { "Peanuts", "Almonds", "Walnuts", "Hazelnuts", "Cashews", "Pistachios", "Macadamia nuts", "Pecans" };
            List<string> SeedsAllergents = new List<string> { "Sunflower seeds", "Pumpkin seeds", "Sesame seeds", "Flaxseeds", "Chia seeds" };
            List<string> FishAllergents = new List<string> { "Salmon", "Tuna", "Cod", "Mackerel", "Herring", "Sardines" };
            List<string> ShellfishAllergents = new List<string> { "Shrimp", "Crab", "Lobster", "Mussels", "Oysters" };
            List<string> SoyAllergents = new List<string> { "Tofu", "Tempeh", "Soy milk", "Edamame", "Soy sauce" };
            List<string> FruitsAllergents = new List<string> { "Apples", "Bananas", "Berries", "strawberries", "raspberries", "blueberries", "Citrus fruits","oranges", "lemons", "grapefruits", "Melon","watermelon", "cantaloupe"};
            List<string> VegetablesAllergents = new List<string> { "Leafy greens","spinach", "kale", "Cruciferous","broccoli", "cauliflower", "Brussels sprouts", "Nightshades","tomatoes", "peppers", "eggplants", "Root", "vegetables","carrots", "potatoes", "beets" };
            List<string> LegumesAllergents = new List<string> { "Lentils", "Chickpeas", "Black beans"," Kidney beans", "Peas" };
            List<string> SweetenersAllergents = new List<string> { "Sugar", "Honey", "Maple syrup", "Agave syrup", "Stevia" };
            List<string> FatsOilsAllergents = new List<string> { "Olive oil", "Coconut oil", "Canola oil", "Butter", "Margarine" };
            List<string> HerbsSpicesAllergents = new List<string> { "Pepper", "Salt", "Cumin", "Turmeric", "Paprika", "Basil", "Oregano" };
            List<string> AdditivesAllergents = new List<string> {"Monosodium glutamate","MSG", "Sulfites", "Color","flavor", "additives" };
            List<string> FermentedAllergents = new List<string> { "Sauerkraut", "Kimchi", "Kombucha", "Miso" };

            char delimiters = '|';
            string[] AllergyList = allergies.Split(delimiters);


            foreach(string allergent in AllergyList)
            {
                switch(allergent)
                {
                    case "0":
                        break;
                    case "1":
                        foreach (string NutAllergent in GrainAllergents)
                        {
                            if (ingedients.Contains(NutAllergent))
                            {
                                return false;
                            }
                        }
                        break;
                    case"2":
                        foreach (string DairyAllergent in DairyAllergents)
                        {
                            if (ingedients.Contains(DairyAllergent))
                            {
                                return false;
                            }
                        }
                        break;
                    case "3":
                        foreach (string EggsAllergent in EggsAllergents)
                        {
                            if (ingedients.Contains(EggsAllergent))
                            {
                                return false;
                            }
                        }
                        break;
                    case "4":
                        foreach (string NutsAllergent in NutsAllergents)
                        {
                            if (ingedients.Contains(NutsAllergent))
                            {
                                return false;
                            }
                        }
                        break;
                    case "5":
                        foreach (string SeedsAllergent in SeedsAllergents)
                        {
                            if (ingedients.Contains(SeedsAllergent))
                            {
                                return false;
                            }
                        }
                        break;
                    case "6":
                        foreach (string FishAllergent in FishAllergents)
                        {
                            if (ingedients.Contains(FishAllergent))
                            {
                                return false;
                            }
                        }
                        break;
                    case "7":
                        foreach (string ShellfishAllergent in ShellfishAllergents)
                        {
                            if (ingedients.Contains(ShellfishAllergent))
                            {
                                return false;
                            }
                        }
                        break;
                    case "8":
                        foreach (string SoyAllergent in SoyAllergents)
                        {
                            if (ingedients.Contains(SoyAllergent))
                            {
                                return false;
                            }
                        }
                        break;
                    case "9":
                        foreach (string FruitsAllergent in FruitsAllergents)
                        {
                            if (ingedients.Contains(FruitsAllergent))
                            {
                                return false;
                            }
                        }
                        break;
                    case "10":
                        foreach (string VegetablesAllergent in VegetablesAllergents)
                        {
                            if (ingedients.Contains(VegetablesAllergent))
                            {
                                return false;
                            }
                        }
                        break;
                    case "11":
                        foreach (string LegumesAllergent in LegumesAllergents)
                        {
                            if (ingedients.Contains(LegumesAllergent))
                            {
                                return false;
                            }
                        }
                        break;
                    case "12":
                        foreach (string SweetenersAllergent in SweetenersAllergents)
                        {
                            if (ingedients.Contains(SweetenersAllergent))
                            {
                                return false;
                            }
                        }
                        break;
                    case "13":
                        foreach (string FatsOilsAllergent in FatsOilsAllergents)
                        {
                            if (ingedients.Contains(FatsOilsAllergent))
                            {
                                return false;
                            }
                        }
                        break;
                    case "14":
                        foreach (string HerbsSpicesAllergent in HerbsSpicesAllergents)
                        {
                            if (ingedients.Contains(HerbsSpicesAllergent))
                            {
                                return false;
                            }
                        }
                        break;
                    case "15":
                        foreach (string AdditivesAllergent in AdditivesAllergents)
                        {
                            if (ingedients.Contains(AdditivesAllergent))
                            {
                                return false;
                            }
                        }
                        break;
                    case "16":
                        foreach (string FermentedAllergent in FermentedAllergents)
                        {
                            if (ingedients.Contains(FermentedAllergent))
                            {
                                return false;
                            }
                        }
                        break;
                }
            }
            return true;
        }

        public async Task<List<Recipe>> GetAllRecipes(string query,string allergies)
        {

            string api_key = "GDhZ4/8euUTcTtCOKOjlKA==UkjauVzTI4jMJJ8H";

            List<Recipe> TotalList = new List<Recipe>();
            List<Recipe> ReturnList = new List<Recipe>();


            using (HttpClient client = new HttpClient())
            {
                var offset = 0;
                int totalList = 0;
                int maxList = 30;


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
                            offset = offset + answer.Count();
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
                    
                    if(offset >= maxList)
                    {
                        break;
                    }
                }

                foreach (Recipe answer in TotalList)
                {
                    if (VerifyAllergy(answer.ingredients, allergies))
                    {
                        ReturnList.Add(answer);
                    }
                }

                return ReturnList;
            }
        }


        
    }
}
