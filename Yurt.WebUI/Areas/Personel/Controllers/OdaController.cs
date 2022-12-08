using Microsoft.AspNetCore.Mvc;
using Yurt.BL.Abstract;
using Yurt.BL.ViewModels.OdaVM;

namespace Yurt.WebUI.Areas.Personel.Controllers
{
    [Area("Personel")]
    public class OdaController : Controller
    {
        private readonly IOdaManager _odaManager;

        public OdaController(IOdaManager odaManager)
        {
            _odaManager = odaManager;
        }

        public async Task<IActionResult> Index()
        {
            var liste = await _odaManager.ListOda();
            return View(liste);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(OdaCreateVM oda)
        {
            if (ModelState.IsValid)
            {
                _odaManager.CreateOda(oda);
                return RedirectToAction("Index");
            }
            else
                ModelState.AddModelError("", "Kayıt Başarısız");

            return View(oda);
        }
    }
}
