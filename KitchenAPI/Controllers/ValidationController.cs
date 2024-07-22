using ClassLibrary.Objects;
using KitchenAPI.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace KitchenAPI.Controllers
{
    [Route("API/")]
    public class ValidationController : Controller
    {

        ValidationHandler validationHandler = new ValidationHandler();

        [HttpGet("ValidateFoody/{Owner}")]
        public async Task<JsonResult> ValidateFood(Guid Owner)
        {
            List<Product> ProductList = await validationHandler.GetBadFood(Owner);
            return Json(ProductList);
        }
    }
}
