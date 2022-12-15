using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Yurt.WebUI.Areas.Personel.Controllers
{
    public class HomeController : Controller
    {
        [Area("Personel")]
        [Authorize(Roles = "Personel")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
