using Yurt.Entites.Entities.Abstract;

namespace Yurt.Entites.Entities.Concrete
{
    public class YurtKayitDetay : BaseEntity
    {
        public int YurtKayitMasterId { get; set; }
        public YurtKayitMaster YurtKayitMaster { get; set; }

        public int OdaId { get; set; }
        public Oda Oda { get; set; }

        //public int OdemeId { get; set; }
        //public Odeme Odeme { get; set; }
    }
}
