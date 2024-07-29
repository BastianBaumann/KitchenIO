using KitchenAPI.Handlers;
using Microsoft.AspNetCore.Mvc;
using KitchenIO.Objects;
using ClassLibrary.Objects;

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


        [HttpPost("CreateProduct")] 
        public async Task<JsonResult> CreateProduct([FromBody] ProductRef newProduct)
        {
            string answer = await productHandler.Create(newProduct);
            return Json(answer);
        }

        [HttpPost("UpdateProduct")] 
        public async Task<JsonResult> UpdateProduct([FromBody] ProductRef Product)
        {
            string answer = await productHandler.Update(Product);
            return Json(answer);
        }

        [HttpPost("DeleteProduct")] 
        public async Task<JsonResult> DeleteInventory([FromBody] ProductRef Product)
        {
            string answer = await productHandler.Delete(Product);
            return Json(answer);
        }
    }
}
