using Yurt.BL.ViewModels.OdemePlaniVM;

namespace Yurt.BL.Abstract
{
    public interface IOdemePlaniManager
    {
        Task<IList<OdemePlaniListVM>> ListOgrenci();
        Task<OdemePlaniCreateVM> CreateOdemePlani(int id);
    }
}
