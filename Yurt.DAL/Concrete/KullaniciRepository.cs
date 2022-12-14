using Yurt.DAL.Abstract;
using Yurt.Entites.Context;
using Yurt.Entites.Entities.Concrete;

namespace Yurt.DAL.Concrete
{
	public class KullaniciRepository : RepositoryBase<Kullanici>, IKullaniciRepository
	{
		public KullaniciRepository(SqlDbContext db) : base(db)
		{
		}
	}
}
