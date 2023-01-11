using Yurt.BL.ViewModels.VeliVM;

namespace Yurt.BL.Abstract
{
    public interface IVeliManager
    {
        Task<IList<VeliListVM>> ListVeli();
        Task<Veli_OgrenciDetayVM> veli_OgrenciDetay(int id);

    }
}
