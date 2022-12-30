namespace Yurt.BL.ViewModels.OdemePlaniVM
{
    public class OdemePlaniCreateVM
    {
        public IList<TaksitOdemeListVM>? TaksitOdemeleri { get; set; }

        public int OdemePlaniId { get; set; }
        public decimal OdenecekTutar { get; set; }

        public IList<string>? Taksit { get; set; }
        public IList<DateTime>? OdemeTarihi { get; set; }
        public IList<decimal>? Tutar { get; set; }
        public IList<decimal>? Odenen { get; set; }
        public IList<decimal>? Kalan { get; set; }
    }
}
