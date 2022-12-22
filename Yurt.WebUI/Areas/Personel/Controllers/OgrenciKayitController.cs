using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Yurt.BL.Abstract;
using Yurt.BL.ViewModels.OgrenciKayitVM;

namespace Yurt.WebUI.Areas.Personel.Controllers
{
    [Area("Personel")]
    public class OgrenciKayitController : Controller
    {
        private readonly IOgrenciKayitManager _ogrenciKayitManager;
        private readonly IOdaManager _odaManager;

        public OgrenciKayitController(IOgrenciKayitManager ogrenciKayitManager, IOdaManager odaManager)
        {
            _ogrenciKayitManager = ogrenciKayitManager;
            _odaManager = odaManager;
        }
        [HttpGet]
        public async Task<IActionResult> OgrenciInsert()
        {
            await SelectListItemOda();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> OgrenciInsert(OgrenciKayitInsertVM ogrenci)
        {
            await _ogrenciKayitManager.CreateOgrenci(ogrenci);
            await SelectListItemOda();
            return View();
        }

        public async Task SelectListItemOda()
        {
            var oda = await _odaManager.ListOda();
            ViewBag.oda = oda.Select(o => new SelectListItem()
            {
                Text = o.OdaNo,
                Value = o.Id.ToString()
            }).ToList();
        }
    }
}
