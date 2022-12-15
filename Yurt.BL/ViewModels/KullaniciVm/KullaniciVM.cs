using System.ComponentModel.DataAnnotations;

namespace Yurt.BL.ViewModels.KullaniciVm
{
    public class KullaniciVM
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kullanici Adi Boş olamaz")]
        public string KullaniciAdi { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Sifre boş olamaz")]
        public string Sifre { get; set; }

        public bool BeniHatirla { get; set; }
    }
}
