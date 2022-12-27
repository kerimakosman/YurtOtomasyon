using Yurt.DAL.Abstract;
using Yurt.Entites.Context;
using Yurt.Entites.Entities.Concrete;

namespace Yurt.DAL.Concrete
{
    public class OdemePlaniRepository : RepositoryBase<OdemePlani>, IOdemePlaniRepository
    {
        public OdemePlaniRepository(SqlDbContext db) : base(db)
        {
        }
    }
}
