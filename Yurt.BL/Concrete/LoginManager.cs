using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Yurt.BL.Abstract;
using Yurt.BL.ViewModels.KullaniciVm;
using Yurt.DAL.Abstract;

namespace Yurt.BL.Concrete
{
	public class LoginManager : ILoginManager
	{
		private readonly IKullaniciRepository _kullaniciRepository;
		private readonly IHttpContextAccessor _httpContextAccessor;


		public LoginManager(IKullaniciRepository kullaniciRepository, IHttpContextAccessor httpContextAccessor)
		{
			_kullaniciRepository = kullaniciRepository;
			_httpContextAccessor = httpContextAccessor;
		}

		public async Task KullaniciContex(KullaniciVM user)
		{
			var kullanici = await _kullaniciRepository.GetFirstAsync(k => k.KullaniciAdi == user.KullaniciAdi && k.Sifre == user.Sifre);
			if (kullanici != null)
			{
				var claims = new List<Claim>()
				{
					new Claim(ClaimTypes.Name,kullanici.KullaniciAdi),
                       //new Claim(ClaimTypes.Role,"Ogrenci"),
                       new Claim(ClaimTypes.Role,kullanici.Rol),
					new Claim(ClaimTypes.GivenName,"Basic")
				};

				var claimIndentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

				var authenticationProperty = new AuthenticationProperties
				{
					IsPersistent = user.BeniHatirla
				};

				await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
				   new ClaimsPrincipal(claimIndentity),
				   authenticationProperty);
			}
			else
			{
				throw new Exception("Kullanıcı Bilgileri Yanlıştır");
			}
		}
	}
}
