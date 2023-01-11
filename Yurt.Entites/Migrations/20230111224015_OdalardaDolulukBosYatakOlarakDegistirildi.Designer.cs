﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Yurt.Entites.Context;

#nullable disable

namespace Yurt.Entites.Migrations
{
    [DbContext(typeof(SqlDbContext))]
    [Migration("20230111224015_OdalardaDolulukBosYatakOlarakDegistirildi")]
    partial class OdalardaDolulukBosYatakOlarakDegistirildi
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kullanicilar");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            KullaniciAdi = "admin",
                            Rol = "Personel",
                            Sifre = "123"
                        });
                });

            modelBuilder.Entity("Yurt.Entites.Entities.Concrete.Oda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte>("BosYatak")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<byte>("Kapasite")
                        .HasColumnType("tinyint");

                    b.Property<bool>("OdaCinsiyet")
                        .HasColumnType("bit");

                    b.Property<string>("OdaNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<decimal>("OdenecekTutar")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("YurtKayitDetayId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("YurtKayitDetayId")
                        .IsUnique();

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

                    b.Property<string>("TcNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ogrenciler");
                });

            modelBuilder.Entity("Yurt.Entites.Entities.Concrete.TaksitOdeme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OdemePlaniId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("OdemeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("Odenen")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Taksit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Tutar")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("OdemePlaniId");

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

                    b.Property<DateTime?>("DogumTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gsm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OgrenciId")
                        .HasColumnType("int");

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

                    b.Property<int>("OdaId")
                        .HasColumnType("int");

                    b.Property<int>("YurtKayitMasterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OdaId");

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

                    b.Property<int>("OgrenciId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OgrenciId")
                        .IsUnique();

                    b.ToTable("YurtKayitMasters");
                });

            modelBuilder.Entity("Yurt.Entites.Entities.Concrete.OdemePlani", b =>
                {
                    b.HasOne("Yurt.Entites.Entities.Concrete.YurtKayitDetay", "YurtKayitDetay")
                        .WithOne("OdemePlani")
                        .HasForeignKey("Yurt.Entites.Entities.Concrete.OdemePlani", "YurtKayitDetayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("YurtKayitDetay");
                });

            modelBuilder.Entity("Yurt.Entites.Entities.Concrete.TaksitOdeme", b =>
                {
                    b.HasOne("Yurt.Entites.Entities.Concrete.OdemePlani", "OdemePlani")
                        .WithMany("TaksitOdemeleri")
                        .HasForeignKey("OdemePlaniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OdemePlani");
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

                    b.HasOne("Yurt.Entites.Entities.Concrete.YurtKayitMaster", "YurtKayitMaster")
                        .WithMany("YurtKayitDetaylari")
                        .HasForeignKey("YurtKayitMasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Oda");

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
                });

            modelBuilder.Entity("Yurt.Entites.Entities.Concrete.Ogrenci", b =>
                {
                    b.Navigation("OgrenciVelileri");

                    b.Navigation("YurtKayitMaster")
                        .IsRequired();
                });

            modelBuilder.Entity("Yurt.Entites.Entities.Concrete.YurtKayitDetay", b =>
                {
                    b.Navigation("OdemePlani")
                        .IsRequired();
                });

            modelBuilder.Entity("Yurt.Entites.Entities.Concrete.YurtKayitMaster", b =>
                {
                    b.Navigation("YurtKayitDetaylari");
                });
#pragma warning restore 612, 618
        }
    }
}
