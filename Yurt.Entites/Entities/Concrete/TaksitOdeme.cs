using Yurt.Entites.Entities.Abstract;

namespace Yurt.Entites.Entities.Concrete
{
    public class TaksitOdeme : BaseEntity
    {
        public int OdemePlaniId { get; set; }
        public OdemePlani OdemePlani { get; set; }


        public string? Taksit { get; set; }
        public DateTime? OdemeTarihi { get; set; }
        public decimal? Tutar { get; set; }
        public decimal? Odenen { get; set; }
    }
}
