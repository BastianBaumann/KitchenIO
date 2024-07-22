using ClassLibrary.Objects;
using KitchenAPI.Handlers;
using KitchenIO.Objects;
using Microsoft.AspNetCore.Mvc;

namespace KitchenAPI.Controllers
{
    [Route("API/")]
    public class InventoryController : Controller
    {
        InventoryHandler InventoryHandler = new InventoryHandler();

        [HttpGet("GetInventory")]
        public async Task<JsonResult> GetInventory()
        {
            List<Product> ProductList = await InventoryHandler.GetAll();
            return Json(ProductList);
        }

        [HttpPost("AddProduct")]
        public async Task<JsonResult> AddProduct([FromBody] Product newProduct)
        {
            string answer = await InventoryHandler.Create(newProduct);
            return Json(answer);
        }
    }
}
