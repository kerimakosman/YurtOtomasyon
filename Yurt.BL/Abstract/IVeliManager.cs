using Yurt.BL.ViewModels.VeliVM;

namespace Yurt.BL.Abstract
{
    public interface IVeliManager
    {
        Task<IList<VeliListVM>> ListVeli();

    }
}
