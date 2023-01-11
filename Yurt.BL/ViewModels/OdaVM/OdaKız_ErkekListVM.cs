using Yurt.Entites.Entities.Concrete;

namespace Yurt.BL.ViewModels.OdaVM
{
    public class OdaKız_ErkekListVM
    {
        public IList<Oda>? ErkekOdalari { get; set; }
        public IList<Oda>? KizOdalari { get; set; }
    }
}
