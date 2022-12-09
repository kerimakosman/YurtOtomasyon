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
                try
                {
                    await _odaManager.CreateOda(oda);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(oda);
                }
            }
            ModelState.AddModelError("", "Kayıt Başarısız");
            return View(oda);
        }
        public async Task<IActionResult> Update(int id)
        {
            var oda = await _odaManager.GetByIdAsync(id);
            return View(oda);
        }
        [HttpPost]
        public async Task<IActionResult> Update(OdaUpdateVM oda)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _odaManager.UpdateOda(oda);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(oda);
                }
            }
            ModelState.AddModelError("", "Kayıt Başarısız");
            return View(oda);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _odaManager.RemoveOda(id);
            return RedirectToAction("Index");
        }
    }
}
