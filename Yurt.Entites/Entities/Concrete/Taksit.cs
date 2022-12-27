using Yurt.Entites.Entities.Abstract;

namespace Yurt.Entites.Entities.Concrete
{
    public class Taksit : BaseEntity
    {
        public string TaksitSayisi { get; set; }
        public ICollection<TaksitOdeme> TaksitOdemeleri { get; set; }
    }
}
