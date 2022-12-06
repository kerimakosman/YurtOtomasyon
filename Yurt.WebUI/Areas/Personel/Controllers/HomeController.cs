using Microsoft.AspNetCore.Mvc;

namespace Yurt.WebUI.Areas.Personel.Controllers
{
    public class HomeController : Controller
    {
        [Area("Personel")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
