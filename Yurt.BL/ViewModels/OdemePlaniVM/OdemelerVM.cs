namespace Yurt.BL.ViewModels.OdemePlaniVM
{
    public class OdemelerVM
    {
        public IList<TaksitOdemeListVM>? TaksitOdemeleri { get; set; }

        public decimal? ToplamOdenen { get; set; }
        public decimal? ToplamKalan { get; set; }

        public int OgrId { get; set; }
        public string? OgrAdi { get; set; }
        public string? OgrSoyadi { get; set; }

        public int OdemePlaniId { get; set; }
        public decimal? ToplamOdenecek { get; set; }

    }
}
