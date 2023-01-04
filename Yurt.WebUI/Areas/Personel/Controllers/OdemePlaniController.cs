using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yurt.BL.Abstract;
using Yurt.BL.ViewModels.OdemePlaniVM;

namespace Yurt.WebUI.Areas.Personel.Controllers
{
    [Area("Personel")]
    [Authorize(Roles = "Personel")]
    public class OdemePlaniController : Controller
    {
        private readonly IOdemePlaniManager _odemePlaniManager;

        public OdemePlaniController(IOdemePlaniManager odemePlaniManager)
        {
            _odemePlaniManager = odemePlaniManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _odemePlaniManager.ListOgrenci());
        }
        [HttpGet("OdemePlani/{id}/{ogrid}")]
        public async Task<IActionResult> CreateOdemePlani(int id, int ogrid)
        {
            var odemePlani = await _odemePlaniManager.CreateOdemePlaniList(id, ogrid);
            return View(odemePlani);
        }
        [HttpPost("OdemePlani/{id}/{ogrid}")]
        public async Task<IActionResult> CreateOdemePlani(OdemePlaniCreateVM odemePlani)
        {
            try
            {
                await _odemePlaniManager.CreateOdemePlani(odemePlani);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(odemePlani);
            }
        }
        [HttpGet("Odemeler/{id}/{ogrid}")]
        public IActionResult Odemeler(int id, int ogrid)
        {
            var odemelerID = _odemePlaniManager.OdemelerListID(id, ogrid);
            return View(odemelerID);
        }
        [HttpGet]
        public async Task<JsonResult> OdemelerList(int id, int ogrid)
        {
            var odemeler = await _odemePlaniManager.OdemelerList(id, ogrid);
            return Json(odemeler);
        }

        [HttpPost]
        public async Task<JsonResult> OdemeYap(int id, decimal odeMiktar)
        {
            await _odemePlaniManager.OdemeYap(id, odeMiktar);
            return Json(true);
        }
    }
}
