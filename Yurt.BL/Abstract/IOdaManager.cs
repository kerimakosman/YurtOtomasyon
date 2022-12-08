using Yurt.Entites.Entities.Concrete;

namespace Yurt.BL.Abstract
{
    public interface IOdaManager
    {
        Task<IList<Oda>> ListOda();
        Task<bool> CreateOda(Oda oda);
    }
}
