using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Yurt.BL.Abstract;
using Yurt.BL.AutoMapper;
using Yurt.BL.Concrete;
using Yurt.DAL.Abstract;
using Yurt.DAL.Concrete;
using Yurt.Entites;
using Yurt.Entites.Context;

namespace Yurt.BL.Extensions
{
    public static class ServisManagerExtensions
    {
        public static IServiceCollection YurtOtomasyonServiceManager(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MyMapper));
            //services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpContextAccessor();

            services.AddDbContext<SqlDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));


            services.AddScoped<IOdaRepository, OdaRepository>();
            services.AddScoped<IOgrenciRepository, OgrenciRepository>();
            services.AddScoped<IVeliRepository, VeliRepository>();
            services.AddScoped<IYurtKayitDetayRepository, YurtKayitDetayRepository>();
            services.AddScoped<IYurtKayitMasterRepository, YurtKayitMasterRepository>();
            services.AddScoped<IKullaniciRepository, KullaniciRepository>();




            services.AddScoped<IOdaManager, OdaManager>();
            services.AddScoped<IOgrenciManager, OgrenciManager>();
            services.AddScoped<IVeliManager, VeliManager>();
            services.AddScoped<ILoginManager, LoginManager>();
            services.AddScoped<IOgrenciKayitManager, OgrenciKayitManager>();



            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Login/Giris";
                    options.LogoutPath = "/Login/Logout";
                    options.Cookie.Name = "YurtOtomasyon";
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                    options.SlidingExpiration = true;
                    options.Cookie.HttpOnly = true;
                    options.AccessDeniedPath = new PathString("/Login/AccesDenied");
                });
            return services;
        }
    }
}
