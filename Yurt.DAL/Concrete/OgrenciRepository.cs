using Yurt.DAL.Abstract;
using Yurt.Entites.Context;
using Yurt.Entites.Entities.Concrete;

namespace Yurt.DAL.Concrete
{
    public class OgrenciRepository : RepositoryBase<Ogrenci>, IOgrenciRepository
    {
        public OgrenciRepository(SqlDbContext db) : base(db)
        {
        }
    }
}
