using Microsoft.EntityFrameworkCore;
using Yurt.BL.Abstract;
using Yurt.BL.ViewModels.OgrenciVM;
using Yurt.DAL.Abstract;

namespace Yurt.BL.Concrete
{
    public class OgrenciManager : IOgrenciManager
    {
        private readonly IOgrenciRepository _ogrenciRepository;
        private readonly IOdaRepository _odaRepository;
        private readonly IYurtKayitDetayRepository _yurtKayitDetayRepository;
        private readonly IYurtKayitMasterRepository _yurtKayitMasterRepository;

        public OgrenciManager(IOgrenciRepository ogrenciRepository, IYurtKayitDetayRepository yurtKayitDetayRepository, IYurtKayitMasterRepository yurtKayitMasterRepository, IOdaRepository odaRepository)
        {
            _ogrenciRepository = ogrenciRepository;
            _yurtKayitDetayRepository = yurtKayitDetayRepository;
            _yurtKayitMasterRepository = yurtKayitMasterRepository;
            _odaRepository = odaRepository;
        }

        public async Task<IList<OgrenciListVM>> ListOgrenci()
        {
            //Odayı yakalıyor yalnız ekranda oda kısmında 
            //system.collections.generic.list`1[<> f__anonymoustype0`1[system.string]]
            //    hatasını veriyor. anonim tipi çeviremediğim için Query Syntax olarak çevirdim.

            //var ogrenci = await _ogrenciRepository.Table
            //                                     .Include(o => o.YurtKayitMaster)
            //                                     .ThenInclude(ykm => ykm.YurtKayitDetaylari)
            //                                     .ThenInclude(ykd => ykd.Oda)
            //                                     .Select(o => new OgrenciListVM()
            //                                     {
            //                                         OgrenciAdi = o.OgrenciAdi,
            //                                         OgrenciSoyadi = o.OgrenciSoyadi,
            //                                         OdaNo = o.YurtKayitMaster.YurtKayitDetaylari.Select(ykm => ykm.Oda.OdaNo).ToString()
            //                                     })
            //                                     .ToListAsync();


            var ogrenci = from o in _ogrenciRepository.Table
                          join ykm in _yurtKayitMasterRepository.Table on o.Id equals ykm.OgrenciId
                          join ykd in _yurtKayitDetayRepository.Table on ykm.Id equals ykd.YurtKayitMasterId
                          join oda in _odaRepository.Table on ykd.OdaId equals oda.Id
                          select new OgrenciListVM
                          {
                              OgrenciId = o.Id,
                              OgrenciAdi = o.OgrenciAdi,
                              OgrenciSoyadi = o.OgrenciSoyadi,
                              OdaNo = oda.OdaNo
                          };
            return await ogrenci.ToListAsync();
        }

        //Ajax ile veriler çekilip öğrenci detaylari modalın içerisine yazdırıldı
        public async Task<OgrenciDetayListVM> OgrenciDetayList(int id)
        {
            var ogrenci = await _ogrenciRepository.Table.Include(ogr => ogr.OgrenciVelileri)
                              .Include(ogr => ogr.YurtKayitMaster)
                              .ThenInclude(ykm => ykm.YurtKayitDetaylari)
                              .ThenInclude(ykd => ykd.Oda)
                              .FirstOrDefaultAsync(ogr => ogr.Id == id);
            if (ogrenci != null)
            {
                OgrenciDetayListVM ogrDetay = new();
                ogrDetay.OgrTel = ogrenci.Gsm;
                ogrDetay.OgrDogumTarihi = ogrenci.DogumTarihi;
                ogrDetay.TcNo = ogrenci.TcNo;
                ogrDetay.Mail = ogrenci.Mail;
                ogrDetay.Cinsiyet = ogrenci.Cinsiyet;
                foreach (var item in ogrenci.OgrenciVelileri)
                {
                    ogrDetay.VeliKim = item.VeliKim;
                    ogrDetay.VeliAdi = item.VeliAdi;
                    ogrDetay.VeliSoyadi = item.VeliSoyadi;
                    ogrDetay.VeliTel = item.Gsm;
                    ogrDetay.VeliDogumTarihi = item.DogumTarihi;
                }
                return ogrDetay;
            }
            throw new Exception("Beklenmedik Bir Hata");
        }

        public async Task RemoveOgrenci(int id)
        {
            await _ogrenciRepository.RemoveAsync(id);
            await _ogrenciRepository.SaveAsync();
        }
    }
}
