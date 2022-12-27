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

        public OgrenciKayitManager(IOgrenciRepository ogrenciRepository, IOdaRepository odaRepository)
        {
            _ogrenciRepository = ogrenciRepository;
            _odaRepository = odaRepository;
        }

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
                        VeliSoyadi=ogrenci.VeliSoyadi
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
            --oda.Doluluk;

            await _ogrenciRepository.SaveAsync();
        }
    }
}
