using Microsoft.AspNetCore.Mvc;

namespace KitchenAPI.Controllers
{
    [Route("API/")]
    public class ProductController : Controller
    {
        ProductHandler newHandler = new ProductHandler();

        [HttpGet("GetTest")]
        public async Task<JsonResult> testProduct()
        {
            var testProduct = newHandler.testProduct();
            return Json(testProduct);
        }
    }
}
