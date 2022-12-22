using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Yurt.Entites.Context;

namespace Yurt.Entites
{
    public class SqlDbContextFactory : IDesignTimeDbContextFactory<SqlDbContext>
    {

        public SqlDbContext CreateDbContext(string[] args)
        {

            DbContextOptionsBuilder<SqlDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configuration.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }

    }
}
