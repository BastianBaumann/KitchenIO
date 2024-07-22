using KitchenAPI.Handlers;
using Microsoft.AspNetCore.Mvc;
using KitchenIO.Objects;

namespace KitchenAPI.Controllers
{
    [Route("API/")]
    public class ProductRefController : Controller
    {
        ProductRefHandler productHandler = new ProductRefHandler();

        [HttpGet("GetAllProducts")]
        public async Task<JsonResult> GetAllProducts()
        {
            List<ProductRef> ProductList = await productHandler.GetAll();
            return Json(ProductList);
        }

        [HttpGet("GetProductByBarcode")]
        public async Task<IActionResult> GetProductByBarcode([FromQuery] string barcode)
        {
            ProductRef foundProduct = await productHandler.GetByBarcode(barcode);
            return Ok(foundProduct);
        }


        [HttpPost("CreateProduct")] //Create a location
        public async Task<JsonResult> CreateProduct([FromBody] ProductRef newProduct)
        {
            string answer = await productHandler.Create(newProduct);
            return Json(answer);
        }

        [HttpPost("UpdateProduct")] //Create a location
        public async Task<JsonResult> UpdateProduct([FromBody] ProductRef newProduct)
        {
            string answer = await productHandler.Create(newProduct);
            return Json(answer);
        }
    }
}
