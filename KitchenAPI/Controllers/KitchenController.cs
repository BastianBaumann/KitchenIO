﻿using ClassLibrary.Objects;
using KitchenAPI.Handlers;
using KitchenIO.Objects;
using Microsoft.AspNetCore.Mvc;

namespace KitchenAPI.Controllers
{
    [Route("API/")]
    public class KitchenController : Controller
    {
        KitchenHandler kitchenHandler = new KitchenHandler();

        [HttpPost("CreateKitchen")]
        public async Task<JsonResult> CreateKitchen([FromBody] Kitchen newKitchen)
        {
            string answer = await kitchenHandler.Create(newKitchen);
            return Json(answer);
        }

        [HttpPost("UpdateKitchen")]
        public async Task<JsonResult> UpdateKitchen([FromBody] Kitchen newKitchen)
        {
            string answer = await kitchenHandler.Update(newKitchen);
            return Json(answer);
        }

        [HttpPost("DeleteKitchen")]
        public async Task<JsonResult> DeleteKitchen([FromBody] Kitchen newKitchen)
        {
            string answer = await kitchenHandler.Delete(newKitchen);
            return Json(answer);
        }

        [HttpGet("GetKitcheById/{KitchenId}")]
        public async Task<JsonResult> GetKitcheById(Guid KitchenId)
        {
            Kitchen answer = await kitchenHandler.getKitchenById(KitchenId);
            return Json(answer);
        }
        
        [HttpGet("GetBindingsByUser/{UserId}")]
        public async Task<JsonResult> GetBindingsByUser(Guid UserId)
        {
            List<Binding> answer = await kitchenHandler.getKitchenBindingByUser(UserId);
            return Json(answer);
        }
    }
}
