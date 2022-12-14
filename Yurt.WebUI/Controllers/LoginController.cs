using Microsoft.AspNetCore.Mvc;

namespace Yurt.WebUI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
