using Yurt.DAL.Abstract;
using Yurt.Entites.Context;
using Yurt.Entites.Entities.Concrete;

namespace Yurt.DAL.Concrete
{
    public class VeliRepository : RepositoryBase<Veli>, IVeliRepository
    {
        public VeliRepository(SqlDbContext db) : base(db)
        {
        }
    }
}
