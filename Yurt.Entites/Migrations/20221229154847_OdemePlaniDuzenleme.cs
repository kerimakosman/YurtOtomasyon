using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yurt.Entites.Migrations
{
    public partial class OdemePlaniDuzenleme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_YurtKayitDetays_OdemePlani_OdemePlaniId",
                table: "YurtKayitDetays");

            migrationBuilder.DropIndex(
                name: "IX_YurtKayitDetays_OdemePlaniId",
                table: "YurtKayitDetays");

            migrationBuilder.DropColumn(
                name: "OdemePlaniId",
                table: "YurtKayitDetays");

            migrationBuilder.AlterColumn<decimal>(
                name: "Tutar",
                table: "TaksitOdemeleri",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Odenen",
                table: "TaksitOdemeleri",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<DateTime>(
                name: "OdemeTarihi",
                table: "TaksitOdemeleri",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "YurtKayitDetayId",
                table: "OdemePlani",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OdemePlani_YurtKayitDetayId",
                table: "OdemePlani",
                column: "YurtKayitDetayId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OdemePlani_YurtKayitDetays_YurtKayitDetayId",
                table: "OdemePlani",
                column: "YurtKayitDetayId",
                principalTable: "YurtKayitDetays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OdemePlani_YurtKayitDetays_YurtKayitDetayId",
                table: "OdemePlani");

            migrationBuilder.DropIndex(
                name: "IX_OdemePlani_YurtKayitDetayId",
                table: "OdemePlani");

            migrationBuilder.DropColumn(
                name: "OdemeTarihi",
                table: "TaksitOdemeleri");

            migrationBuilder.DropColumn(
                name: "YurtKayitDetayId",
                table: "OdemePlani");

            migrationBuilder.AddColumn<int>(
                name: "OdemePlaniId",
                table: "YurtKayitDetays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "Tutar",
                table: "TaksitOdemeleri",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Odenen",
                table: "TaksitOdemeleri",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

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
    }
}
