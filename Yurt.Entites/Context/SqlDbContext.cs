using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Yurt.Entites.Entities.Concrete;

namespace Yurt.Entites.Context
{
    public class SqlDbContext : DbContext
    {

        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {
        }

        public DbSet<Ogrenci> Ogrenciler { get; set; }
        public DbSet<Oda> Odalar { get; set; }
        public DbSet<Veli> Veliler { get; set; }
        public DbSet<YurtKayitMaster> YurtKayitMasters { get; set; }
        public DbSet<YurtKayitDetay> YurtKayitDetays { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<OdemePlani> OdemePlani { get; set; }
        public DbSet<Taksit> Taksitler { get; set; }
        public DbSet<TaksitOdeme> TaksitOdemeleri { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
