using Microsoft.AspNetCore.Mvc;

namespace KitchenAPI.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
