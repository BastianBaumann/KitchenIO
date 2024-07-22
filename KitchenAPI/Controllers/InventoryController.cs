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

        [HttpPost("UpdateInventory")] //Create a location
        public async Task<JsonResult> UpdateInventory([FromBody] Product Product)
        {
            string answer = await InventoryHandler.Update(Product);
            return Json(answer);
        }

        [HttpPost("DeleteInventory")] //Create a location
        public async Task<JsonResult> DeleteInventory([FromBody] Product Product)
        {
            string answer = await InventoryHandler.Delete(Product);
            return Json(answer);
        }

        [HttpGet("GetByOwnerInventory/{Owner}")]
        public async Task<JsonResult> GetByOwnerInventory(Guid Owner)
        {
            List<Product> answer = await InventoryHandler.GetByOwner(Owner);
            return Json(answer);
        }
    }
}
