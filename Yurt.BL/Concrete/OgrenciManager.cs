﻿using Microsoft.EntityFrameworkCore;
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
                              OgrenciAdi = o.OgrenciAdi,
                              OgrenciSoyadi = o.OgrenciSoyadi,
                              OdaNo = oda.OdaNo
                          };
            return await ogrenci.ToListAsync();
        }

        //var result = (from p in db.Products
        //                  join od in db.OrderDetails on p.ProductId equals od.ProductId
        //                  join o in db.Orders on od.OrderId equals o.OrderId
        //                  select new
        //                  {
        //                      p.ProductId,
        //                      p.ProductName,
        //                      o.OrderDate,
        //                      o.ShipCountry,
        //                      o.ShipCity
        //                  }).ToList();
    }
}
