using ClassLibrary.Objects;
using KitchenAPI.Handlers;
using KitchenIO.Objects;
using Microsoft.AspNetCore.Mvc;

namespace KitchenAPI.Controllers
{
    [Route("API/")]
    public class UserController : Controller
    {
        UserHandler userHandler = new UserHandler();

        [HttpPost("CreateUser")]
        public async Task<JsonResult> Create(User newUser)
        {
            string answer = await userHandler.Create(newUser);
            return Json(answer);
        }

        [HttpPost("UpdateUser")]
        public async Task<JsonResult> Update(User newUser)
        {
            string answer = await userHandler.Update(newUser);
            return Json(answer);
        }

        [HttpGet("Delete/{UserId}")]
        public async Task<JsonResult> Delete(Guid UserId)
        {
            string answer = await userHandler.Delete(UserId);
            return Json(answer);
        }
    }
}
