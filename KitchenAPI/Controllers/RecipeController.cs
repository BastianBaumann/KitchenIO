using ClassLibrary.Objects;
using KitchenAPI.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace KitchenAPI.Controllers
{
    [Route("API/")]
    public class RecipeController : Controller
    {
        RecipeHandler recipeHandler = new RecipeHandler();

        [HttpGet("GetRecipes/{query}")]
        public async Task<JsonResult> GetRecipes(string query)
        {
            List<Recipe> answer = await recipeHandler.GetAllRecipes(query);
            return Json(answer);
        }
    }
}
