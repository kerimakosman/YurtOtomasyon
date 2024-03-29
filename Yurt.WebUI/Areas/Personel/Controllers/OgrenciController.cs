﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yurt.BL.Abstract;

namespace Yurt.WebUI.Areas.Personel.Controllers
{
    [Area("Personel")]
    [Authorize(Roles = "Personel")]
    public class OgrenciController : Controller
    {
        private readonly IOgrenciManager _ogrenciManager;

        public OgrenciController(IOgrenciManager ogrenciManager)
        {
            _ogrenciManager = ogrenciManager;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _ogrenciManager.ListOgrenci());
        }
        public async Task<JsonResult> DetayOgrenci(int id)
        {
            var deyayOgr = await _ogrenciManager.OgrenciDetayList(id);
            return Json(deyayOgr);
        }
        public async Task<IActionResult> OgrenciDelete(int id)
        {
            await _ogrenciManager.RemoveOgrenci(id);
            return RedirectToAction("Index");
        }
    }
}
