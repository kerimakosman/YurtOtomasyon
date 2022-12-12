﻿using Microsoft.EntityFrameworkCore;
using Yurt.Entites.Entities.Concrete;

namespace Yurt.Entites.Context
{
    public class SqlDbContext : DbContext
    {
        //public SqlDbContext() { }
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options) { }

        public DbSet<Ogrenci> Ogrenciler { get; set; }
        public DbSet<Oda> Odalar { get; set; }
        public DbSet<Veli> Veliler { get; set; }
        public DbSet<YurtKayitMaster> YurtKayitMasters { get; set; }
        public DbSet<YurtKayitDetay> YurtKayitDetays { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=YurtOtomasyon;Trusted_Connection=true");
        //}
    }
}
