using Yurt.BL.Abstract;
using Yurt.BL.ViewModels.OgrenciKayitVM;
using Yurt.DAL.Abstract;
using Yurt.Entites.Entities.Concrete;

namespace Yurt.BL.Concrete
{
	public class OgrenciKayitManager : IOgrenciKayitManager
	{
		private readonly IOgrenciRepository _ogrenciRepository;

		public OgrenciKayitManager(IOgrenciRepository ogrenciRepository)
		{
			_ogrenciRepository = ogrenciRepository;
		}

		public async Task CreateOgrenci(OgrenciKayitInsertVM ogrenci)
		{
			await _ogrenciRepository.AddAsync(new()
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
						new(){OdaId=ogrenci.OdaId}
					}
				}
			});
			await _ogrenciRepository.SaveAsync();
		}
	}
}
