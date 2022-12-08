using Yurt.BL.Abstract;
using Yurt.DAL.Abstract;
using Yurt.Entites.Entities.Concrete;

namespace Yurt.BL.Concrete
{
    public class OdaManager : IOdaManager
    {
        private readonly IOdaRepository _odaRepository;

        public OdaManager(IOdaRepository odaRepository)
        {
            _odaRepository = odaRepository;
        }

        public async Task<IList<Oda>> ListOda()
            => await _odaRepository.GetAllAsync();

        public Task<bool> CreateOda(Oda oda)
        {
            throw new NotImplementedException();
        }

    }
}
