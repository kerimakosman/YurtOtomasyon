using Yurt.BL.ViewModels.OgrenciVM;

namespace Yurt.BL.Abstract
{
    public interface IOgrenciManager
    {
        Task<IList<OgrenciListVM>> ListOgrenci();
        Task RemoveOgrenci(int id);
    }
}
