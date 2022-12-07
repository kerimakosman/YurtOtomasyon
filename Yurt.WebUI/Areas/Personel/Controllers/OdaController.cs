using Microsoft.AspNetCore.Mvc;
using Yurt.BL.Abstract;
using Yurt.Entites.Entities.Concrete;

namespace Yurt.WebUI.Areas.Personel.Controllers
{
    [Area("Personel")]
    public class OdaController : Controller
    {
        private readonly IOdaManager odaManager;

        public OdaController(IOdaManager odaManager)
        {
            this.odaManager = odaManager;
        }

        public async Task<IActionResult> Index()
        {
            var liste = await odaManager.GetAllAsync();
            return View(liste);
        }

        public IActionResult Create()
        {
            Oda oda = new Oda();
            return View(oda);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Oda oda)
        {
            await odaManager.AddAsync(oda);
            return RedirectToAction("Index");

        }
    }
}
