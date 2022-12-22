using Microsoft.EntityFrameworkCore;
using Yurt.Entites.Entities.Abstract;
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




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kullanici>().HasData(
                new { Id = 1, CreateDate = new DateTime(2023, 01, 01), Status = Status.Active, KullaniciAdi = "admin", Sifre = "123", Rol = "Personel" });
        }
    }
}
