using Yurt.Entites.Entities.Abstract;

namespace Yurt.Entites.Entities.Concrete
{
    public class Oda : BaseEntity
    {
        public Oda()
        {
            YurtKayitDetaylari = new HashSet<YurtKayitDetay>();
        }
        public string OdaNo { get; set; }
        public byte Kapasite { get; set; }
        public byte Doluluk { get; set; }
        public bool OdaCinsiyet { get; set; }

        public ICollection<YurtKayitDetay> YurtKayitDetaylari { get; set; }
    }
}
