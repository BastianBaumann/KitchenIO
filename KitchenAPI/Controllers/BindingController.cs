using ClassLibrary.Objects;
using KitchenAPI.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace KitchenAPI.Controllers
{
    [Route("Bindings/")]
    public class BindingController : Controller
    {
        
        BindingHandler bindingHandler = new BindingHandler();

        [HttpPost("BindKitchen")]
        public async Task<JsonResult> BindKitchen([FromBody] Binding newBInd)
        {
            string answer = await bindingHandler.BindKitchen(newBInd);
            return Json(answer);
        }

        [HttpGet("DeleteBindUsery/{UserId}/{KitchenId}")]
        public async Task<JsonResult> DeleteBindingByUser(Guid UserId, Guid KitchenId)
        {
            string answer = await bindingHandler.DeleteBindingByUser(UserId, KitchenId);
            return Json(answer);
        }

        [HttpPost("DeleteBindKitcheny/{KitchenId}")]
        public async Task<JsonResult> DeleteBindingByKitchen(Guid KitchenId)
        {
            string answer = await bindingHandler.DeleteBindingByKitchen(KitchenId);
            return Json(answer);
        }

        [HttpGet("GetBindingsByUser/{BindingUserId}")]
        public async Task<JsonResult> GetBindingsByUser(Guid BindingUserId)
        {
            List<Binding> answer = await bindingHandler.GetByUser(BindingUserId);
            return Json(answer);
        }

        [HttpGet("GetUsersByKitchen/{KitchenId}")]
        public async Task<JsonResult> GetUsersByKitchen(Guid KitchenId)
        {
            List<User> answer = await bindingHandler.GetByKitchen(KitchenId);
            return Json(answer);
        }
    }
}
