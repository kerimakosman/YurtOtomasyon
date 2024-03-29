﻿namespace Yurt.BL.ViewModels.OgrenciKayitVM
{
    public class OgrenciKayitEditVM
    {
        //Ogrenci 
        public int OgrenciId { get; set; }
        public string OgrenciAdi { get; set; }
        public string OgrenciSoyadi { get; set; }
        public string? OgrGsm { get; set; }
        public string? TcNo { get; set; }
        public string? Mail { get; set; }
        public bool Cinsiyet { get; set; }
        public DateTime? OgrDogumTarihi { get; set; }
        //Veli
        public int VeliId { get; set; }
        public string VeliKim { get; set; }
        public string VeliAdi { get; set; }
        public string VeliSoyadi { get; set; }
        public string? VeliGsm { get; set; }
        public DateTime? VeliDogumTarihi { get; set; }
        //Oda
        public int OdaId { get; set; }
        public string OdaNo { get; set; }
    }
}
