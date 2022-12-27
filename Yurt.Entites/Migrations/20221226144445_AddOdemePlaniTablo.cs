using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yurt.Entites.Migrations
{
    public partial class AddOdemePlaniTablo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OdemePlaniId",
                table: "YurtKayitDetays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "OdemePlani",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OdenecekTutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ToplamOdenen = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    KalanOdeme = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdemePlani", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_YurtKayitDetays_OdemePlaniId",
                table: "YurtKayitDetays",
                column: "OdemePlaniId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_YurtKayitDetays_OdemePlani_OdemePlaniId",
                table: "YurtKayitDetays",
                column: "OdemePlaniId",
                principalTable: "OdemePlani",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_YurtKayitDetays_OdemePlani_OdemePlaniId",
                table: "YurtKayitDetays");

            migrationBuilder.DropTable(
                name: "OdemePlani");

            migrationBuilder.DropIndex(
                name: "IX_YurtKayitDetays_OdemePlaniId",
                table: "YurtKayitDetays");

            migrationBuilder.DropColumn(
                name: "OdemePlaniId",
                table: "YurtKayitDetays");
        }
    }
}
