using Microsoft.EntityFrameworkCore;
using Yurt.BL.Abstract;
using Yurt.BL.ViewModels.OgrenciKayitVM;
using Yurt.DAL.Abstract;
using Yurt.Entites.Entities.Concrete;

namespace Yurt.BL.Concrete
{
    public class OgrenciKayitManager : IOgrenciKayitManager
    {
        private readonly IOgrenciRepository _ogrenciRepository;
        private readonly IOdaRepository _odaRepository;
        private readonly IVeliRepository _veliRepository;

        public OgrenciKayitManager(IOgrenciRepository ogrenciRepository, IOdaRepository odaRepository, IVeliRepository veliRepository)
        {
            _ogrenciRepository = ogrenciRepository;
            _odaRepository = odaRepository;
            _veliRepository = veliRepository;
        }
        //HasSet üzerinden tablolar arası ÖğrenciKayıt ile alakalı bilgiler alınıp kaydedildi. Öğrenci nin cinsiyetine ve odanın dolu-boş olmasına göre ajax üzerinden oda seçimi yapıldı.OdaManager içerisinde method.
        public async Task CreateOgrenci(OgrenciKayitInsertVM ogrenci)
        {
            Ogrenci ogrenci1 = new()
            {
                OgrenciAdi = ogrenci.OgrenciAdi,
                OgrenciSoyadi = ogrenci.OgrenciSoyadi,
                Cinsiyet = ogrenci.Cinsiyet,
                DogumTarihi = ogrenci.OgrDogumTarihi,
                Mail = ogrenci.Mail,
                Gsm = ogrenci.OgrGsm,
                TcNo = ogrenci.TcNo,
                OgrenciVelileri = new HashSet<Veli>()
                {
                    new()
                    {
                        VeliKim=ogrenci.VeliKim,
                        VeliAdi=ogrenci.VeliAdi,
                        VeliSoyadi=ogrenci.VeliSoyadi,
                        Gsm=ogrenci.VeliGsm,
                        DogumTarihi=ogrenci.VeliDogumTarihi
                    }
                },
                YurtKayitMaster = new()
                {
                    YurtKayitDetaylari = new HashSet<YurtKayitDetay>()
                    {
                        new()
                        {
                            OdaId=ogrenci.OdaId,
                            OdemePlani =new()
                            {
                                OdenecekTutar=ogrenci.OdenecekTutar
                            }
                        }
                    }
                }
            };
            await _ogrenciRepository.AddAsync(ogrenci1);
            var oda = await _odaRepository.GetByIdAsync(ogrenci.OdaId);
            --oda.BosYatak;

            await _ogrenciRepository.SaveAsync();
        }
        //OgrenciKayit güncellemenin View sayfasına gidecek olan bilgiler gönderildi
        public async Task<OgrenciKayitEditVM> EditOgrenciGet(int ogrId)
        {
            var ogrenci = await _ogrenciRepository.Table.Include(o => o.OgrenciVelileri)
                          .Include(o => o.YurtKayitMaster)
                          .ThenInclude(ykm => ykm.YurtKayitDetaylari)
                          .ThenInclude(ykd => ykd.Oda)
                          .FirstOrDefaultAsync(o => o.Id == ogrId);
            OgrenciKayitEditVM ogrEdit = new()
            {
                OgrenciId = ogrenci.Id,
                OgrenciAdi = ogrenci.OgrenciAdi,
                OgrenciSoyadi = ogrenci.OgrenciSoyadi,
                OgrGsm = ogrenci.Gsm,
                TcNo = ogrenci.TcNo,
                Mail = ogrenci.Mail,
                Cinsiyet = ogrenci.Cinsiyet,
                OgrDogumTarihi = ogrenci.DogumTarihi
            };
            foreach (var item in ogrenci.YurtKayitMaster.YurtKayitDetaylari)
            {
                ogrEdit.OdaId = item.OdaId;
                ogrEdit.OdaNo = item.Oda.OdaNo;
            }
            foreach (var item in ogrenci.OgrenciVelileri)
            {
                ogrEdit.VeliId = item.Id;
                ogrEdit.VeliKim = item.VeliKim;
                ogrEdit.VeliAdi = item.VeliAdi;
                ogrEdit.VeliSoyadi = item.VeliSoyadi;
                ogrEdit.VeliGsm = item.Gsm;
                ogrEdit.VeliDogumTarihi = item.DogumTarihi;
            }
            return ogrEdit;
        }
        public async Task EditOgrenciPost(OgrenciKayitEditVM ogrenciEdit)
        {
            var ogrenci = await _ogrenciRepository.Table.Include(o => o.OgrenciVelileri)
                          .Include(o => o.YurtKayitMaster)
                          .ThenInclude(ykm => ykm.YurtKayitDetaylari)
                          .ThenInclude(ykd => ykd.Oda)
                          .FirstOrDefaultAsync(o => o.Id == ogrenciEdit.OgrenciId);
            ogrenci.OgrenciAdi = ogrenciEdit.OgrenciAdi;
            ogrenci.OgrenciSoyadi = ogrenciEdit.OgrenciSoyadi;
            ogrenci.Gsm = ogrenciEdit.OgrGsm;
            ogrenci.TcNo = ogrenciEdit.TcNo;
            ogrenci.Mail = ogrenciEdit.Mail;
            ogrenci.Cinsiyet = ogrenciEdit.Cinsiyet;
            ogrenci.DogumTarihi = ogrenciEdit.OgrDogumTarihi;

            var updateVeli = await _veliRepository.GetByIdAsync(ogrenciEdit.VeliId);
            updateVeli.VeliKim = ogrenciEdit.VeliKim;
            updateVeli.VeliAdi = ogrenciEdit.VeliAdi;
            updateVeli.VeliSoyadi = ogrenciEdit.VeliSoyadi;
            updateVeli.Gsm = ogrenciEdit.VeliGsm;
            updateVeli.DogumTarihi = ogrenciEdit.VeliDogumTarihi;

            foreach (var item in ogrenci.YurtKayitMaster.YurtKayitDetaylari)
            {
                ++item.Oda.BosYatak;
                item.OdaId = ogrenciEdit.OdaId;
            }
            var yeniOda = await _odaRepository.GetByIdAsync(ogrenciEdit.OdaId);
            --yeniOda.BosYatak;

            await _ogrenciRepository.SaveAsync();
        }
    }
}
