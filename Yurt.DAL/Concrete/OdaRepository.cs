using Yurt.DAL.Abstract;
using Yurt.Entites.Context;
using Yurt.Entites.Entities.Concrete;

namespace Yurt.DAL.Concrete
{
    public class OdaRepository : RepositoryBase<Oda>, IOdaRepository
    {
        public OdaRepository(SqlDbContext db) : base(db)
        {
        }
    }
}
