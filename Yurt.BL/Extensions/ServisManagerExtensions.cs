using Microsoft.Extensions.DependencyInjection;
using Yurt.BL.Abstract;
using Yurt.BL.AutoMapper;
using Yurt.BL.Concrete;
using Yurt.DAL.Abstract;
using Yurt.DAL.Concrete;

namespace Yurt.BL.Extensions
{
    public static class ServisManagerExtensions
    {
        public static IServiceCollection YurtOtomasyonServiceManager(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MyMapper));

            services.AddScoped<IOdaManager, OdaManager>();
            services.AddScoped<IOdaRepository, OdaRepository>();

            services.AddScoped<IOgrenciManager, OgrenciManager>();
            services.AddScoped<IOgrenciRepository, OgrenciRepository>();

            return services;
        }
    }
}
