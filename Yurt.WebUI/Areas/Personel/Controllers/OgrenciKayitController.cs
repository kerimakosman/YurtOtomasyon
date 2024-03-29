﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yurt.BL.Abstract;
using Yurt.BL.ViewModels.OgrenciKayitVM;

namespace Yurt.WebUI.Areas.Personel.Controllers
{
    [Area("Personel")]
    [Authorize(Roles = "Personel")]
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
        public IActionResult OgrenciInsert()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> OgrenciInsert(OgrenciKayitInsertVM ogrenci)
        {
            await _ogrenciKayitManager.CreateOgrenci(ogrenci);
            return RedirectToAction("Index", "OdemePlani", new { Area = "Personel" });
        }
        [HttpGet("OgrenciKayitGuncelle")]
        public async Task<IActionResult> OgrenciEdit(int id)
        {
            var ogrEdit = await _ogrenciKayitManager.EditOgrenciGet(id);
            return View(ogrEdit);
        }
        [HttpPost("OgrenciKayitGuncelle")]
        public async Task<IActionResult> OgrenciEdit(OgrenciKayitEditVM ogrenciEdit)
        {
            await _ogrenciKayitManager.EditOgrenciPost(ogrenciEdit);
            return RedirectToAction("Index", "Ogrenci", new { Area = "Personel" });
        }
        [HttpGet]
        public async Task<JsonResult> SelectListOda(bool oda)
        {
            var kızErkekOda = await _odaManager.KızErkekListOda(oda);
            return Json(kızErkekOda);
        }
    }
}
