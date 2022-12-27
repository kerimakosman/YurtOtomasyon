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

        public OdemePlaniManager(IOgrenciRepository ogrenciRepository, IOdaRepository odaRepository, IYurtKayitDetayRepository yurtKayitDetayRepository, IYurtKayitMasterRepository yurtKayitMasterRepository, IOdemePlaniRepository odemePlaniRepository, IVeliRepository veliRepository)
        {
            _ogrenciRepository = ogrenciRepository;
            _odaRepository = odaRepository;
            _yurtKayitDetayRepository = yurtKayitDetayRepository;
            _yurtKayitMasterRepository = yurtKayitMasterRepository;
            _odemePlaniRepository = odemePlaniRepository;
            _veliRepository = veliRepository;
        }

        public async Task<IList<OdemePlaniListVM>> ListOgrenci()
        {
            var odemeList = from o in _ogrenciRepository.Table
                            join v in _veliRepository.Table on o.Id equals v.OgrenciId
                            join ykm in _yurtKayitMasterRepository.Table on o.Id equals ykm.OgrenciId
                            join ykd in _yurtKayitDetayRepository.Table on ykm.Id equals ykd.YurtKayitMasterId
                            join oda in _odaRepository.Table on ykd.OdaId equals oda.Id
                            join op in _odemePlaniRepository.Table on ykd.OdemePlaniId equals op.Id
                            select new OdemePlaniListVM
                            {
                                OgrenciAdi = o.OgrenciAdi,
                                OgrenciSoyadi = o.OgrenciSoyadi,
                                VeliAdi = v.VeliAdi,
                                VeliSoyadi = v.VeliSoyadi,
                                OdaNo = oda.OdaNo,
                                OdemePlaniId = op.Id
                            };
            return await odemeList.OrderBy(o => o.OdemePlaniId).ToListAsync();
        }
    }
}
