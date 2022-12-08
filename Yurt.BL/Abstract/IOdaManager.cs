using Yurt.BL.ViewModels.OdaVM;
using Yurt.Entites.Entities.Concrete;

namespace Yurt.BL.Abstract
{
    public interface IOdaManager
    {
        Task<IList<Oda>> ListOda();
        Task CreateOda(OdaCreateVM oda);
    }
}
