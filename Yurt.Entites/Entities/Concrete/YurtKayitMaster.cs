using Yurt.Entites.Entities.Abstract;

namespace Yurt.Entites.Entities.Concrete
{
    public class YurtKayitMaster : BaseEntity
    {
        public YurtKayitMaster()
        {
            YurtKayitDetaylari = new HashSet<YurtKayitDetay>();
        }


        //public int CalisanId { get; set; }
        //public Calisan? Calisan { get; set; }

        public int OgrenciId { get; set; }
        public Ogrenci Ogrenci { get; set; }
        public ICollection<YurtKayitDetay> YurtKayitDetaylari { get; set; }
    }
}