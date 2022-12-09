using AutoMapper;
using Yurt.BL.ViewModels.OdaVM;
using Yurt.Entites.Entities.Concrete;

namespace Yurt.BL.AutoMapper
{
    public class MyMapper : Profile
    {
        public MyMapper()
        {
            CreateMap<Oda, OdaCreateVM>().ReverseMap();
            CreateMap<Oda, OdaUpdateVM>().ReverseMap();

        }
    }
}
