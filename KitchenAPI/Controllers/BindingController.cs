using ClassLibrary.Objects;
using KitchenAPI.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace KitchenAPI.Controllers
{
    [Route("API/")]
    public class BindingController : Controller
    {
        
        BindingHandler bindingHandler = new BindingHandler();

        [HttpPost("BindKitchen")]
        public async Task<JsonResult> BindKitchen([FromBody] Binding newBInd)
        {
            string answer = await bindingHandler.BindKitchen(newBInd);
            return Json(answer);
        }

        [HttpPost("DeleteBindUsery/{UserId}")]
        public async Task<JsonResult> DeleteBindingByUser(Guid UserId)
        {
            string answer = await bindingHandler.DeleteBindingByUser(UserId);
            return Json(answer);
        }

        [HttpPost("DeleteBindKitcheny/{KitchenId}")]
        public async Task<JsonResult> DeleteBindingByKitchen(Guid KitchenId)
        {
            string answer = await bindingHandler.DeleteBindingByKitchen(KitchenId);
            return Json(answer);
        }
    }
}
