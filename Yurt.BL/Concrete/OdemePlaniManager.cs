using Microsoft.EntityFrameworkCore;
using Yurt.BL.Abstract;
using Yurt.BL.ViewModels.OdemePlaniVM;
using Yurt.DAL.Abstract;
using Yurt.Entites.Entities.Concrete;

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
                                OgrenciId = ogr.Id,
                                OdemePlaniId = op.Id,
                                OdaNo = oda.OdaNo,
                                OgrenciAdi = ogr.OgrenciAdi,
                                OgrenciSoyadi = ogr.OgrenciSoyadi,
                                VeliAdi = veli.VeliAdi,
                                VeliSoyadi = veli.VeliSoyadi,
                                CreateDate = op.CreateDate
                            };
            return await odemeList.OrderByDescending(op => op.CreateDate).ToListAsync();
        }
        public async Task<OdemePlaniCreateVM> CreateOdemePlaniList(int id, int ogrid)
        {
            var odemePlani = await _odemePlaniRepository.GetByIdAsync(id);
            var ogrenci = await _ogrenciRepository.GetByIdAsync(ogrid);

            OdemePlaniCreateVM odemePlaniCreateVM = new()
            {
                OgrId = ogrenci.Id,
                OgrAdi = ogrenci.OgrenciAdi,
                OgrSoyadi = ogrenci.OgrenciSoyadi,
                //TaksitOdemeleri = taksitOdeme,
                OdemePlaniId = odemePlani.Id,
                OdenecekTutar = odemePlani.OdenecekTutar
            };
            return odemePlaniCreateVM;
        }

        public async Task CreateOdemePlani(OdemePlaniCreateVM odemePlani)
        {
            var toplamTaksit = odemePlani.Taksit.Count();
            var ogr = await _ogrenciRepository.GetByIdAsync(odemePlani.OgrId);
            odemePlani.OgrAdi = ogr.OgrenciAdi;
            odemePlani.OgrSoyadi = ogr.OgrenciSoyadi;

            decimal toplamTutar = 0;
            for (int i = 0; i < toplamTaksit; i++)
            {
                toplamTutar += odemePlani.Tutar[i];
            }

            if (toplamTutar == odemePlani.OdenecekTutar)
            {
                var odenecekTutar = await _odemePlaniRepository.GetByIdAsync(odemePlani.OdemePlaniId);
                odenecekTutar.OdenecekTutar = odemePlani.OdenecekTutar;
                for (int i = 0; i < toplamTaksit; i++)
                {
                    TaksitOdeme taksitOdeme = new TaksitOdeme();
                    taksitOdeme.OdemePlaniId = odemePlani.OdemePlaniId;
                    taksitOdeme.Taksit = odemePlani.Taksit[i];
                    taksitOdeme.OdemeTarihi = odemePlani.OdemeTarihi[i];
                    taksitOdeme.Tutar = odemePlani.Tutar[i];
                    taksitOdeme.Odenen = 0;
                    await _taksitOdemeRepository.AddAsync(taksitOdeme);
                }
                //await _taksitOdemeRepository.SaveAsync();
            }
            else
            {
                throw new Exception("ToplamTutar ile ÖdenecekTutar eşit değil");
            }
        }
        public OdemelerVM OdemelerListID(int id, int ogrid)
        {
            return new() { OdemePlaniId = id, OgrId = ogrid };
        }
        public async Task<OdemelerVM> OdemelerList(int id, int ogrid)
        {
            var taksitOdeme = await _taksitOdemeRepository.Table
                                    .Include(to => to.OdemePlani)
                                    .Where(to => to.OdemePlaniId == id)
                                    .Select(to => new TaksitOdemeListVM
                                    {
                                        TaksitOdemeId = to.Id,
                                        Taksit = to.Taksit,
                                        OdemeTarihi = to.OdemeTarihi,
                                        Tutar = to.Tutar,
                                        Odenen = to.Odenen,
                                        Kalan = to.Tutar - to.Odenen
                                    }).ToListAsync();

            var ogrenci = await _ogrenciRepository.GetByIdAsync(ogrid);

            return new()
            {
                TaksitOdemeleri = taksitOdeme,
                OdemePlaniId = id,
                OgrId = ogrid,
                OgrAdi = ogrenci.OgrenciAdi,
                OgrSoyadi = ogrenci.OgrenciSoyadi,
                ToplamOdenecek = taksitOdeme.Sum(to => to.Tutar),
                ToplamOdenen = taksitOdeme.Sum(p => p.Odenen),
                ToplamKalan = taksitOdeme.Sum(to => to.Kalan)
            };
        }
        public async Task OdemeYap(int id, decimal odeMiktar)
        {
            var taksitOdeme = await _taksitOdemeRepository.GetByIdAsync(id);
            taksitOdeme.Odenen += odeMiktar;
            var kalan = taksitOdeme.Tutar - taksitOdeme.Odenen;
            if (kalan < 0 || odeMiktar <= 0)
            {
                throw new Exception("Odeme Basarisiz oldu");
            }
            await _taksitOdemeRepository.SaveAsync();
        }
    }
}
