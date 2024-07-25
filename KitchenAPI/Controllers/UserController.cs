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
        public async Task<JsonResult> CreateUser([FromBody] User newUser)
        {
            string answer = await userHandler.Create(newUser);
            return Json(answer);
        }

        [HttpPost("UpdateUser")]
        public async Task<JsonResult> UpdateUser([FromBody] User newUser)
        {
            string answer = await userHandler.Update(newUser);
            return Json(answer);
        }

        [HttpGet("DeleteUser/{UserId}")]
        public async Task<JsonResult> DeleteUser(Guid UserId)
        {
            string answer = await userHandler.Delete(UserId);
            return Json(answer);
        }

        [HttpGet("LoginUser/{Username}/{Userpassword}")]
        public async Task<JsonResult> LoginUser(string Username, string Userpassword)
        {
            Guid answer = await userHandler.Login(Username, Userpassword);
            return Json(answer);
        }

        [HttpGet("GetUserByName/{Username}")]
        public async Task<JsonResult> GetUserByName(string Username)
        {
            User answer = await userHandler.GetByName(Username);
            return Json(answer);
        }
    }
}
