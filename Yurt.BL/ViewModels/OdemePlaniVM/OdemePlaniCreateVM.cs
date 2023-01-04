namespace Yurt.BL.ViewModels.OdemePlaniVM
{
    public class OdemePlaniCreateVM
    {

        public int OgrId { get; set; }
        public string? OgrAdi { get; set; }
        public string? OgrSoyadi { get; set; }

        public int OdemePlaniId { get; set; }
        public decimal OdenecekTutar { get; set; }


        public IList<string>? Taksit { get; set; }
        public IList<DateTime>? OdemeTarihi { get; set; }
        public IList<decimal>? Tutar { get; set; }
    }
}
