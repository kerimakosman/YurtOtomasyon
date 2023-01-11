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
                           VeliGsm = v.Gsm,
                           OgrenciId = o.Id,
                           OgrenciAdi = o.OgrenciAdi,
                           OgrenciSoyadi = o.OgrenciSoyadi
                       };
            return await veli.ToListAsync();
        }

        public async Task<Veli_OgrenciDetayVM> veli_OgrenciDetay(int id)
        {
            var ogrenci = await _ogrenciRepository.Table.Include(ogr => ogr.OgrenciVelileri)
                              .Include(ogr => ogr.YurtKayitMaster)
                              .ThenInclude(ykm => ykm.YurtKayitDetaylari)
                              .ThenInclude(ykd => ykd.Oda)
                              .FirstOrDefaultAsync(ogr => ogr.Id == id);
            if (ogrenci != null)
            {
                Veli_OgrenciDetayVM ogrDetay = new();
                ogrDetay.OgrGsm = ogrenci.Gsm;
                ogrDetay.DogumTarihi = ogrenci.DogumTarihi;
                ogrDetay.OgrTcNo = ogrenci.TcNo;

                foreach (var item in ogrenci.YurtKayitMaster.YurtKayitDetaylari)
                {
                    ogrDetay.OdaNo = item.Oda.OdaNo;
                }
                return ogrDetay;
            }
            throw new Exception("Beklenmedik Bir Hata");
        }
    }
}

