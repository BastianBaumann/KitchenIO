using ClassLibrary.Objects;
using KitchenAPI.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace KitchenAPI.Controllers
{
    [Route("API/")]
    public class RecipeController : Controller
    {
        RecipeHandler recipeHandler = new RecipeHandler();

        [HttpGet("GetRecipes/{query}/{allergies}")]
        public async Task<JsonResult> GetRecipes(string query,string allergies)
        {
            List<Recipe> answer = await recipeHandler.GetAllRecipes(query, allergies);
            return Json(answer);
        }
    }
}
