using System.ComponentModel.DataAnnotations;

namespace Yurt.BL.ViewModels.OdaVM
{
    public class OdaCreateVM
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Oda No zorunlu alan")]
        public string OdaNo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Kapasite zorunlu alan")]
        public byte Kapasite { get; set; }
    }
}
