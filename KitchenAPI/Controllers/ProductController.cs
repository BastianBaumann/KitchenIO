using KitchenAPI.Handlers;
using Microsoft.AspNetCore.Mvc;
using KitchenIO.Objects;

namespace KitchenAPI.Controllers
{
    [Route("API/")]
    public class ProductController : Controller
    {
        ProductHandler productHandler = new ProductHandler();

        [HttpGet("GetAllProducts")]
        public async Task<JsonResult> GetAllProducts()
        {
            List<Product> ProductList = await productHandler.GetAll();
            return Json(ProductList);
        }

        [HttpPost("CreateProduct")] //Create a location
        public async Task<JsonResult> CreateLocation([FromBody] Product newProduct)
        {
            string answer = await productHandler.Create(newProduct);
            return Json(answer);
        }
    }
}
