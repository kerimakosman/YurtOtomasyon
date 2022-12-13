using Yurt.Entites.Entities.Abstract;

namespace Yurt.Entites.Entities.Concrete
{
    public class Ogrenci : BaseEntity
    {
        public Ogrenci()
        {
            OgrenciVelileri = new HashSet<Veli>();
        }
        public string OgrenciAdi { get; set; }
        public string OgrenciSoyadi { get; set; }
        public string? Gsm { get; set; }
        public string? TcNo { get; set; }
        public string? Mail { get; set; }
        public bool Cinsiyet { get; set; }
        public DateTime? DogumTarihi { get; set; }

        public YurtKayitMaster YurtKayitMaster { get; set; }
        public ICollection<Veli> OgrenciVelileri { get; set; }
    }
}
