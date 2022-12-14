using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yurt.Entites.Migrations
{
    public partial class AddKullaniciTablo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_YurtKayitMasters_OgrenciId",
                table: "YurtKayitMasters");

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Kullanicilar",
                columns: new[] { "Id", "CreateDate", "DeleteDate", "KullaniciAdi", "Rol", "Sifre", "Status", "UpdateDate" },
                values: new object[] { 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin", "Personel", "123", 1, null });

            migrationBuilder.CreateIndex(
                name: "IX_YurtKayitMasters_OgrenciId",
                table: "YurtKayitMasters",
                column: "OgrenciId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropIndex(
                name: "IX_YurtKayitMasters_OgrenciId",
                table: "YurtKayitMasters");

            migrationBuilder.CreateIndex(
                name: "IX_YurtKayitMasters_OgrenciId",
                table: "YurtKayitMasters",
                column: "OgrenciId");
        }
    }
}
