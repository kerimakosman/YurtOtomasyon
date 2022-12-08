using Yurt.Entites.Entities.Abstract;

namespace Yurt.Entites.Entities.Concrete
{
    public class Veli : BaseEntity
    {
        public string VeliKim { get; set; }
        public string VeliAdi { get; set; }
        public string VeliSoyadi { get; set; }
        public string? Gsm { get; set; }
        public DateTime? DogumTarihi { get; set; }

        public int OgrenciId { get; set; }
        public Ogrenci Ogrenci { get; set; }
    }
}
