using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yurt.BL.Abstract;

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
        public async Task<IActionResult> CreateOdemePlani()
        {
            return View();
        }
        //[HttpPost]
        //public async Task<IActionResult> CreateOdemePlani()
        //{
        //    return View();
        //}
    }
}
