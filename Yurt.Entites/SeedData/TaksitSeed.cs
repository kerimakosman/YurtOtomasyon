using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yurt.Entites.Entities.Concrete;

namespace Yurt.Entites.SeedData
{
    public class TaksitSeed : IEntityTypeConfiguration<Taksit>
    {
        public void Configure(EntityTypeBuilder<Taksit> builder)
        {
            builder.HasData(
                new Taksit { Id = 1, TaksitSayisi = "1.Taksit" },
                new Taksit { Id = 2, TaksitSayisi = "2.Taksit" },
                new Taksit { Id = 3, TaksitSayisi = "3.Taksit" },
                new Taksit { Id = 4, TaksitSayisi = "4.Taksit" },
                new Taksit { Id = 5, TaksitSayisi = "5.Taksit" },
                new Taksit { Id = 6, TaksitSayisi = "6.Taksit" },
                new Taksit { Id = 7, TaksitSayisi = "7.Taksit" },
                new Taksit { Id = 8, TaksitSayisi = "8.Taksit" },
                new Taksit { Id = 9, TaksitSayisi = "9.Taksit" },
                new Taksit { Id = 10, TaksitSayisi = "10.Taksit" },
                new Taksit { Id = 11, TaksitSayisi = "11.Taksit" },
                new Taksit { Id = 12, TaksitSayisi = "12.Taksit" }
                );
        }
    }
}
