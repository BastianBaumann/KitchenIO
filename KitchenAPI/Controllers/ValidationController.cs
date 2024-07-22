using ClassLibrary.Objects;
using KitchenAPI.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace KitchenAPI.Controllers
{
    [Route("API/")]
    public class ValidationController : Controller
    {

        ValidationHandler validationHandler = new ValidationHandler();

        [HttpGet("ValidateFood")]
        public async Task<JsonResult> ValidateFood(Guid owner)
        {
            List<Product> ProductList = await validationHandler.GetBadFood(owner);
            return Json(ProductList);
        }
    }
}
