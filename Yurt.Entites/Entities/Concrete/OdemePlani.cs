using Yurt.Entites.Entities.Abstract;

namespace Yurt.Entites.Entities.Concrete
{
    public class OdemePlani : BaseEntity
    {
        public OdemePlani()
        {
            TaksitOdemeleri = new HashSet<TaksitOdeme>();
        }

        public decimal OdenecekTutar { get; set; }
        //public decimal? ToplamOdenen { get; set; }
        //public decimal? KalanOdeme { get; set; }

        public int YurtKayitDetayId { get; set; }
        public YurtKayitDetay YurtKayitDetay { get; set; }

        public ICollection<TaksitOdeme> TaksitOdemeleri { get; set; }

    }
}
