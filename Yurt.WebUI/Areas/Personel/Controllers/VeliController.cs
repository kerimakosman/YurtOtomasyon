using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yurt.BL.Abstract;

namespace Yurt.WebUI.Areas.Personel.Controllers
{
    [Area("Personel")]
    [Authorize(Roles = "Personel")]
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
        public async Task<JsonResult> OgrenciBilgi(int id)
        {
            var result = await _veliManager.veli_OgrenciDetay(id);
            return Json(result);
        }
    }
}
