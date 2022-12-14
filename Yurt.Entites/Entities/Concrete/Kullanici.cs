using Yurt.Entites.Entities.Abstract;

namespace Yurt.Entites.Entities.Concrete
{

	public class Kullanici : BaseEntity
	{
		public string KullaniciAdi { get; set; }
		public string Sifre { get; set; }

		string _rol = "Ogrenci";
		public string Rol { get => _rol; set => _rol = value; }
	}
}
