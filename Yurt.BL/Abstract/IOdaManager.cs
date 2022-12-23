using Yurt.BL.ViewModels.OdaVM;
using Yurt.Entites.Entities.Concrete;

namespace Yurt.BL.Abstract
{
    public interface IOdaManager
    {
        Task<IList<Oda>> ListOda();
        Task CreateOda(OdaCreateVM oda);
        Task<OdaUpdateVM> GetByIdAsync(int id);
        Task UpdateOda(OdaUpdateVM oda);
        Task RemoveOda(int id);
        Task<IList<Oda>> KızErkekListOda(bool oda);
    }
}
