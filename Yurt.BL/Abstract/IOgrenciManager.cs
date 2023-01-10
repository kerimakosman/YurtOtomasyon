using Yurt.BL.ViewModels.OgrenciVM;

namespace Yurt.BL.Abstract
{
    public interface IOgrenciManager
    {
        Task<IList<OgrenciListVM>> ListOgrenci();
        Task<OgrenciDetayListVM> OgrenciDetayList(int id);
        Task RemoveOgrenci(int id);
    }
}
