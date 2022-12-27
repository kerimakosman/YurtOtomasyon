using Yurt.Entites.Entities.Abstract;

namespace Yurt.Entites.Entities.Concrete
{
    public class OdemePlani : BaseEntity
    {
        public decimal OdenecekTutar { get; set; }
        public decimal? ToplamOdenen { get; set; }
        public decimal? KalanOdeme { get; set; }

        public YurtKayitDetay YurtKayitDetay { get; set; }
    }
}
