﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Yurt.Entites.Context;

#nullable disable

namespace Yurt.Entites.Migrations
{
    [DbContext(typeof(SqlDbContext))]
    partial class SqlDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Yurt.Entites.Entities.Concrete.Kullanici", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Kullanicilar");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            KullaniciAdi = "admin",
                            Rol = "Personel",
                            Sifre = "123",
                            Status = 1
                        });
                });

            modelBuilder.Entity("Yurt.Entites.Entities.Concrete.Oda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<byte>("Doluluk")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Kapasite")
                        .HasColumnType("tinyint");

                    b.Property<bool>("OdaCinsiyet")
                        .HasColumnType("bit");

                    b.Property<string>("OdaNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Odalar");
                });

            modelBuilder.Entity("Yurt.Entites.Entities.Concrete.OdemePlani", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("OdenecekTutar")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("OdemePlani");
                });

            modelBuilder.Entity("Yurt.Entites.Entities.Concrete.Ogrenci", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Cinsiyet")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DogumTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gsm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OgrenciAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OgrenciSoyadi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("TcNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Ogrenciler");
                });

            modelBuilder.Entity("Yurt.Entites.Entities.Concrete.Taksit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("TaksitSayisi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Taksitler");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2022, 12, 27, 22, 56, 56, 673, DateTimeKind.Local).AddTicks(6442),
                            Status = 1,
                            TaksitSayisi = "1.Taksit"
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2022, 12, 27, 22, 56, 56, 673, DateTimeKind.Local).AddTicks(6455),
                            Status = 1,
                            TaksitSayisi = "2.Taksit"
                        },
                        new
                        {
                            Id = 3,
                            CreateDate = new DateTime(2022, 12, 27, 22, 56, 56, 673, DateTimeKind.Local).AddTicks(6457),
                            Status = 1,
                            TaksitSayisi = "3.Taksit"
                        },
                        new
                        {
                            Id = 4,
                            CreateDate = new DateTime(2022, 12, 27, 22, 56, 56, 673, DateTimeKind.Local).AddTicks(6462),
                            Status = 1,
                            TaksitSayisi = "4.Taksit"
                        },
                        new
                        {
                            Id = 5,
                            CreateDate = new DateTime(2022, 12, 27, 22, 56, 56, 673, DateTimeKind.Local).AddTicks(6464),
                            Status = 1,
                            TaksitSayisi = "5.Taksit"
                        },
                        new
                        {
                            Id = 6,
                            CreateDate = new DateTime(2022, 12, 27, 22, 56, 56, 673, DateTimeKind.Local).AddTicks(6466),
                            Status = 1,
                            TaksitSayisi = "6.Taksit"
                        },
                        new
                        {
                            Id = 7,
                            CreateDate = new DateTime(2022, 12, 27, 22, 56, 56, 673, DateTimeKind.Local).AddTicks(6469),
                            Status = 1,
                            TaksitSayisi = "7.Taksit"
                        },
                        new
                        {
                            Id = 8,
                            CreateDate = new DateTime(2022, 12, 27, 22, 56, 56, 673, DateTimeKind.Local).AddTicks(6471),
                            Status = 1,
                            TaksitSayisi = "8.Taksit"
                        },
                        new
                        {
                            Id = 9,
                            CreateDate = new DateTime(2022, 12, 27, 22, 56, 56, 673, DateTimeKind.Local).AddTicks(6473),
                            Status = 1,
                            TaksitSayisi = "9.Taksit"
                        },
                        new
                        {
                            Id = 10,
                            CreateDate = new DateTime(2022, 12, 27, 22, 56, 56, 673, DateTimeKind.Local).AddTicks(6476),
                            Status = 1,
                            TaksitSayisi = "10.Taksit"
                        },
                        new
                        {
                            Id = 11,
                            CreateDate = new DateTime(2022, 12, 27, 22, 56, 56, 673, DateTimeKind.Local).AddTicks(6479),
                            Status = 1,
                            TaksitSayisi = "11.Taksit"
                        },
                        new
                        {
                            Id = 12,
                            CreateDate = new DateTime(2022, 12, 27, 22, 56, 56, 673, DateTimeKind.Local).AddTicks(6481),
                            Status = 1,
                            TaksitSayisi = "12.Taksit"
                        });
                });

            modelBuilder.Entity("Yurt.Entites.Entities.Concrete.TaksitOdeme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OdemePlaniId")
                        .HasColumnType("int");

                    b.Property<decimal>("Odenen")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TaksitId")
                        .HasColumnType("int");

                    b.Property<decimal>("Tutar")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OdemePlaniId");

                    b.HasIndex("TaksitId");

                    b.ToTable("TaksitOdemeleri");
                });

            modelBuilder.Entity("Yurt.Entites.Entities.Concrete.Veli", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DogumTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gsm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OgrenciId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("VeliAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VeliKim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VeliSoyadi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OgrenciId");

                    b.ToTable("Veliler");
                });

            modelBuilder.Entity("Yurt.Entites.Entities.Concrete.YurtKayitDetay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OdaId")
                        .HasColumnType("int");

                    b.Property<int>("OdemePlaniId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("YurtKayitMasterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OdaId");

                    b.HasIndex("OdemePlaniId")
                        .IsUnique();

                    b.HasIndex("YurtKayitMasterId");

                    b.ToTable("YurtKayitDetays");
                });

            modelBuilder.Entity("Yurt.Entites.Entities.Concrete.YurtKayitMaster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OgrenciId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OgrenciId")
                        .IsUnique();

                    b.ToTable("YurtKayitMasters");
                });

            modelBuilder.Entity("Yurt.Entites.Entities.Concrete.TaksitOdeme", b =>
                {
                    b.HasOne("Yurt.Entites.Entities.Concrete.OdemePlani", "OdemePlani")
                        .WithMany("TaksitOdemeleri")
                        .HasForeignKey("OdemePlaniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Yurt.Entites.Entities.Concrete.Taksit", "Taksit")
                        .WithMany("TaksitOdemeleri")
                        .HasForeignKey("TaksitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OdemePlani");

                    b.Navigation("Taksit");
                });

            modelBuilder.Entity("Yurt.Entites.Entities.Concrete.Veli", b =>
                {
                    b.HasOne("Yurt.Entites.Entities.Concrete.Ogrenci", "Ogrenci")
                        .WithMany("OgrenciVelileri")
                        .HasForeignKey("OgrenciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ogrenci");
                });

            modelBuilder.Entity("Yurt.Entites.Entities.Concrete.YurtKayitDetay", b =>
                {
                    b.HasOne("Yurt.Entites.Entities.Concrete.Oda", "Oda")
                        .WithMany("YurtKayitDetaylari")
                        .HasForeignKey("OdaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Yurt.Entites.Entities.Concrete.OdemePlani", "OdemePlani")
                        .WithOne("YurtKayitDetay")
                        .HasForeignKey("Yurt.Entites.Entities.Concrete.YurtKayitDetay", "OdemePlaniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Yurt.Entites.Entities.Concrete.YurtKayitMaster", "YurtKayitMaster")
                        .WithMany("YurtKayitDetaylari")
                        .HasForeignKey("YurtKayitMasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Oda");

                    b.Navigation("OdemePlani");

                    b.Navigation("YurtKayitMaster");
                });

            modelBuilder.Entity("Yurt.Entites.Entities.Concrete.YurtKayitMaster", b =>
                {
                    b.HasOne("Yurt.Entites.Entities.Concrete.Ogrenci", "Ogrenci")
                        .WithOne("YurtKayitMaster")
                        .HasForeignKey("Yurt.Entites.Entities.Concrete.YurtKayitMaster", "OgrenciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ogrenci");
                });

            modelBuilder.Entity("Yurt.Entites.Entities.Concrete.Oda", b =>
                {
                    b.Navigation("YurtKayitDetaylari");
                });

            modelBuilder.Entity("Yurt.Entites.Entities.Concrete.OdemePlani", b =>
                {
                    b.Navigation("TaksitOdemeleri");

                    b.Navigation("YurtKayitDetay")
                        .IsRequired();
                });

            modelBuilder.Entity("Yurt.Entites.Entities.Concrete.Ogrenci", b =>
                {
                    b.Navigation("OgrenciVelileri");

                    b.Navigation("YurtKayitMaster")
                        .IsRequired();
                });

            modelBuilder.Entity("Yurt.Entites.Entities.Concrete.Taksit", b =>
                {
                    b.Navigation("TaksitOdemeleri");
                });

            modelBuilder.Entity("Yurt.Entites.Entities.Concrete.YurtKayitMaster", b =>
                {
                    b.Navigation("YurtKayitDetaylari");
                });
#pragma warning restore 612, 618
        }
    }
}
