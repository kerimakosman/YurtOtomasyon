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
        [HttpGet("OdemePlani/{id}")]
        public async Task<IActionResult> CreateOdemePlani(int id)
        {
            var odemePlani = await _odemePlaniManager.CreateOdemePlani(id);
            return View(odemePlani);
        }
        [HttpPost("OdemePlani/{id}")]
        public async Task<IActionResult> CreateOdemePlani(OdemePlaniCreateVM odemePlani)
        {
            return RedirectToAction("CreateOdemePlani");
        }
    }
}
