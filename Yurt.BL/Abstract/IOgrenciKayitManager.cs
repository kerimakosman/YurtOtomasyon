using Yurt.BL.ViewModels.OgrenciKayitVM;

namespace Yurt.BL.Abstract
{
	public interface IOgrenciKayitManager
	{
		Task CreateOgrenci(OgrenciKayitInsertVM ogrenci);
	}
}
