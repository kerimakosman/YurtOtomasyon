using Yurt.Entites.Entities.Abstract;

namespace Yurt.Entites.Entities.Concrete
{
    public class TaksitOdeme : BaseEntity
    {
        public int TaksitId { get; set; }
        public Taksit Taksit { get; set; }

        public int OdemePlaniId { get; set; }
        public OdemePlani OdemePlani { get; set; }


        public decimal Tutar { get; set; }
        public decimal Odenen { get; set; }
    }
}
