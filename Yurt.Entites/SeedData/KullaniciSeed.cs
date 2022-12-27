using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yurt.Entites.Entities.Abstract;
using Yurt.Entites.Entities.Concrete;

namespace Yurt.Entites.SeedData
{
    public class KullaniciSeed : IEntityTypeConfiguration<Kullanici>
    {
        public void Configure(EntityTypeBuilder<Kullanici> builder)
        {
            builder.HasData(
                new { Id = 1, CreateDate = new DateTime(2023, 01, 01), Status = Status.Active, KullaniciAdi = "admin", Sifre = "123", Rol = "Personel" }
                );
        }
    }
}
