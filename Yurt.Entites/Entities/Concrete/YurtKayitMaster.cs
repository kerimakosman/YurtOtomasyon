using Yurt.Entites.Entities.Abstract;

namespace Yurt.Entites.Entities.Concrete
{
    public class YurtKayitMaster : BaseEntity
    {
        //public int CalisanId { get; set; }
        //public Calisan? Calisan { get; set; }

        public int OgrenciId { get; set; }
        public Ogrenci Ogrenci { get; set; }
        public IList<YurtKayitDetay> YurtKayitDetaylari { get; set; }
    }
}