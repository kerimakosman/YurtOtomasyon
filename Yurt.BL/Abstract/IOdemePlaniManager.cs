using Yurt.BL.ViewModels.OdemePlaniVM;

namespace Yurt.BL.Abstract
{
    public interface IOdemePlaniManager
    {
        Task<IList<OdemePlaniListVM>> ListOgrenci();
        Task<OdemePlaniCreateVM> CreateOdemePlaniList(int id, int ogrid);
        Task CreateOdemePlani(OdemePlaniCreateVM odemePlani);
        Task<OdemelerVM> OdemelerList(int id, int ogrid);
        OdemelerVM OdemelerListID(int id, int ogrid);
        Task OdemeYap(int id, decimal odeMiktar);
    }
}
