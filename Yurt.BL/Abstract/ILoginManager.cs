using Yurt.BL.ViewModels.KullaniciVm;

namespace Yurt.BL.Abstract
{
    public interface ILoginManager
    {
        Task KullaniciContex(KullaniciVM user);
    }
}
