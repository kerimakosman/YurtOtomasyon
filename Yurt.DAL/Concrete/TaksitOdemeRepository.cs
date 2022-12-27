using Yurt.DAL.Abstract;
using Yurt.Entites.Context;
using Yurt.Entites.Entities.Concrete;

namespace Yurt.DAL.Concrete
{
    public class TaksitOdemeRepository : RepositoryBase<TaksitOdeme>, ITaksitOdemeRepository
    {
        public TaksitOdemeRepository(SqlDbContext db) : base(db)
        {
        }
    }
}
