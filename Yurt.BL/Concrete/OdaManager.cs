using AutoMapper;
using Yurt.BL.Abstract;
using Yurt.BL.ViewModels.OdaVM;
using Yurt.DAL.Abstract;
using Yurt.Entites.Entities.Concrete;

namespace Yurt.BL.Concrete
{
    public class OdaManager : IOdaManager
    {
        private readonly IOdaRepository _odaRepository;
        private readonly IMapper _mapper;
        public OdaManager(IOdaRepository odaRepository, IMapper mapper)
        {
            _odaRepository = odaRepository;
            _mapper = mapper;
        }

        public async Task<IList<Oda>> ListOda()
        {
            return await _odaRepository.GetAllAsync();
        }

        public async Task CreateOda(OdaCreateVM oda)
        {
            var firstOda = await _odaRepository.GetFirstAsync(o => o.OdaNo == oda.OdaNo);

            if (firstOda != null)
            {
                throw new Exception("Daha önce bu oda kaydedildi");
            }
            else
            {
                var createOda = _mapper.Map<Oda>(oda);
                await _odaRepository.AddAsync(createOda);
                await _odaRepository.SaveAsync();
            }
        }
        public async Task<OdaUpdateVM> GetByIdAsync(int id)
        {
            var updateOda = await _odaRepository.GetByIdAsync(id);
            return _mapper.Map<OdaUpdateVM>(updateOda);
        }

        public async Task UpdateOda(OdaUpdateVM oda)
        {
            var firstOda = await _odaRepository.GetFirstAsync(o => o.OdaNo == oda.OdaNo);
            if (firstOda == null || firstOda.Id == oda.Id)
            {
                var updateOda = await _odaRepository.GetByIdAsync(oda.Id);
                //var updateOda = _mapper.Map<Oda>(oda);
                //_odaRepository.Update(updateOda);
                //CreateDate tekrar güncellediği için burada AutoMap kullanmaktan vazgeçtim.
                updateOda.OdaNo = oda.OdaNo;
                updateOda.Kapasite = oda.Kapasite;
                updateOda.UpdateDate = DateTime.Now;
                await _odaRepository.SaveAsync();
            }
            else
            {
                throw new Exception("Daha önce bu oda kaydedildi");
            }
        }

        public async Task RemoveOda(int id)
        {
            await _odaRepository.RemoveAsync(id);
            await _odaRepository.SaveAsync();
        }
        public async Task<IList<Oda>> KızErkekListOda(bool oda)
        {
            return await _odaRepository.GetAllAsync(o => o.OdaCinsiyet == oda);
        }
    }
}
