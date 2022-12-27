using Yurt.DAL.Abstract;
using Yurt.Entites.Context;
using Yurt.Entites.Entities.Concrete;

namespace Yurt.DAL.Concrete
{
    public class TaksitRepository : RepositoryBase<Taksit>, ITaksitRepository
    {
        public TaksitRepository(SqlDbContext db) : base(db)
        {
        }
    }
}
