using Yurt.DAL.Abstract;
using Yurt.Entites.Context;
using Yurt.Entites.Entities.Concrete;

namespace Yurt.DAL.Concrete
{
    public class YurtKayitMasterRepository : RepositoryBase<YurtKayitMaster>, IYurtKayitMasterRepository
    {
        public YurtKayitMasterRepository(SqlDbContext db) : base(db)
        {
        }
    }
}
