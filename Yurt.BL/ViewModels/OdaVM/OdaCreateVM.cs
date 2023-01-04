using System.ComponentModel.DataAnnotations;

namespace Yurt.BL.ViewModels.OdaVM
{
    public class OdaCreateVM
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Oda No zorunlu alan")]
        public string OdaNo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Kapasite zorunlu alan")]
        [Range(1, int.MaxValue, ErrorMessage = "Oda kapasitesini doğru girdiğinizden emin olun")]
        public byte Kapasite { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "KızOda-ErkekOda zorunlu alan")]
        public bool OdaCinsiyet { get; set; }

    }
}
