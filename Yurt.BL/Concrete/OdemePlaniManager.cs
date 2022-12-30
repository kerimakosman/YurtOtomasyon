using Microsoft.EntityFrameworkCore;
using Yurt.BL.Abstract;
using Yurt.BL.ViewModels.OdemePlaniVM;
using Yurt.DAL.Abstract;

namespace Yurt.BL.Concrete
{
    public class OdemePlaniManager : IOdemePlaniManager
    {
        private readonly IOgrenciRepository _ogrenciRepository;
        private readonly IOdaRepository _odaRepository;
        private readonly IYurtKayitDetayRepository _yurtKayitDetayRepository;
        private readonly IYurtKayitMasterRepository _yurtKayitMasterRepository;
        private readonly IOdemePlaniRepository _odemePlaniRepository;
        private readonly IVeliRepository _veliRepository;
        private readonly ITaksitOdemeRepository _taksitOdemeRepository;

        public OdemePlaniManager(IOgrenciRepository ogrenciRepository, IOdaRepository odaRepository, IYurtKayitDetayRepository yurtKayitDetayRepository, IYurtKayitMasterRepository yurtKayitMasterRepository, IOdemePlaniRepository odemePlaniRepository, IVeliRepository veliRepository, ITaksitOdemeRepository taksitOdemeRepository)
        {
            _ogrenciRepository = ogrenciRepository;
            _odaRepository = odaRepository;
            _yurtKayitDetayRepository = yurtKayitDetayRepository;
            _yurtKayitMasterRepository = yurtKayitMasterRepository;
            _odemePlaniRepository = odemePlaniRepository;
            _veliRepository = veliRepository;
            _taksitOdemeRepository = taksitOdemeRepository;
        }

        public async Task<IList<OdemePlaniListVM>> ListOgrenci()
        {
            var odemeList = from op in _odemePlaniRepository.Table
                            join ykd in _yurtKayitDetayRepository.Table on op.YurtKayitDetayId equals ykd.Id
                            join ykm in _yurtKayitMasterRepository.Table on ykd.YurtKayitMasterId equals ykm.Id
                            join ogr in _ogrenciRepository.Table on ykm.OgrenciId equals ogr.Id
                            join veli in _veliRepository.Table on ogr.Id equals veli.OgrenciId
                            join oda in _odaRepository.Table on ykd.OdaId equals oda.Id
                            select new OdemePlaniListVM()
                            {
                                OdemePlaniId = op.Id,
                                OdaNo = oda.OdaNo,
                                OgrenciAdi = ogr.OgrenciAdi,
                                OgrenciSoyadi = ogr.OgrenciSoyadi,
                                VeliAdi = veli.VeliAdi,
                                VeliSoyadi = veli.VeliSoyadi
                            };
            return await odemeList.OrderByDescending(op => op.OdemePlaniId).ToListAsync();
        }
        public async Task<OdemePlaniCreateVM> CreateOdemePlani(int id)
        {
            var odemePlani = _taksitOdemeRepository.Table
                            .Include(to => to.OdemePlani);
            var _odeme1 = await odemePlani.FirstOrDefaultAsync(to => to.OdemePlani.Id == id);

            var _odeme2 = await odemePlani.Where(to => to.OdemePlaniId == id)
                   .Select(to => new TaksitOdemeListVM
                   {
                       Taksit = to.Taksit,
                       OdemeTarihi = to.OdemeTarihi,
                       Tutar = to.Tutar,
                       Odenen = to.Odenen,
                       Kalan = to.Tutar - to.Odenen
                   }).ToListAsync();
            OdemePlaniCreateVM asd = new();
            asd.TaksitOdemeleri = _odeme2;
            asd.OdemePlaniId = _odeme1.OdemePlani.Id;
            asd.OdenecekTutar = _odeme1.OdemePlani.OdenecekTutar;
            return new()
            {
                TaksitOdemeleri = _odeme2,
                OdemePlaniId = _odeme1.OdemePlani.Id,
                OdenecekTutar = _odeme1.OdemePlani.OdenecekTutar
            };
        }
    }
}
