using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yurt.BL.Abstract;
using Yurt.BL.ViewModels.KullaniciVm;

namespace Yurt.WebUI.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{
		private readonly ILoginManager _loginManager;

		public LoginController(ILoginManager loginManager)
		{
			_loginManager = loginManager;
		}
		public IActionResult Giris()
		{
			if (User.Identity.IsAuthenticated)
			{
				if (User.IsInRole("Personel"))
				{
					return RedirectToAction("Index", "Home", new { Area = "Personel" });
				}
				else if (User.IsInRole("Ogrenci"))
				{
					return RedirectToAction("Index", "Home");
				}
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Giris(KullaniciVM user)
		{
			try
			{
				await _loginManager.KullaniciContex(user);
				return RedirectToAction("Giris");
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("", ex.Message);
				return View(user);
			}
		}
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync();
			return RedirectToAction("Giris");
		}
		public IActionResult AccesDenied()
		{
			return View();
		}

	}
}
