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
            var createOda = _mapper.Map<Oda>(oda);
            await _odaRepository.AddAsync(createOda);
            await _odaRepository.SaveAsync();
        }

    }
}
