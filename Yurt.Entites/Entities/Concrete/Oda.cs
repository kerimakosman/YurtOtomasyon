using Yurt.Entites.Entities.Abstract;

namespace Yurt.Entites.Entities.Concrete
{
    public class Oda : BaseEntity
    {
        //public Oda()
        //{
        //    Ogrenciler = new HashSet<Ogrenci>();
        //}
        public string OdaNo { get; set; }
        public byte Kapasite { get; set; }

        //public ICollection<Ogrenci> Ogrenciler { get; set; }
    }
}
