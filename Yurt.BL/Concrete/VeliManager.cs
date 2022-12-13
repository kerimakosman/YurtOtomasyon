using Microsoft.EntityFrameworkCore;
using Yurt.BL.Abstract;
using Yurt.BL.ViewModels.VeliVM;
using Yurt.DAL.Abstract;

namespace Yurt.BL.Concrete
{
    public class VeliManager : IVeliManager
    {
        private readonly IVeliRepository _veliRepository;
        private readonly IOgrenciRepository _ogrenciRepository;
        public VeliManager(IVeliRepository veliRepository, IOgrenciRepository ogrenciRepository)
        {
            _veliRepository = veliRepository;
            _ogrenciRepository = ogrenciRepository;
        }

        public async Task<IList<VeliListVM>> ListVeli()
        {
            var veli = from v in _veliRepository.Table
                       join o in _ogrenciRepository.Table on v.OgrenciId equals o.Id
                       select new VeliListVM
                       {
                           VeliKim = v.VeliKim,
                           VeliAdi = v.VeliAdi,
                           VeliSoyadi = v.VeliSoyadi,
                           OgrenciAdi = o.OgrenciAdi,
                           OgrenciSoyadi = o.OgrenciSoyadi
                       };
            return await veli.ToListAsync();
        }
    }
}

