using Microsoft.AspNetCore.Mvc;
using Yurt.BL.Abstract;

namespace Yurt.WebUI.Areas.Personel.Controllers
{
    [Area("Personel")]
    public class VeliController : Controller
    {
        private readonly IVeliManager _veliManager;

        public VeliController(IVeliManager veliManager)
        {
            _veliManager = veliManager;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _veliManager.ListVeli());
        }
    }
}
