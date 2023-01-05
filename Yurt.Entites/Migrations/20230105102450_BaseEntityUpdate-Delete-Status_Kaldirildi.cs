using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yurt.Entites.Migrations
{
    public partial class BaseEntityUpdateDeleteStatus_Kaldirildi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "YurtKayitMasters");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "YurtKayitMasters");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "YurtKayitMasters");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "YurtKayitDetays");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "YurtKayitDetays");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "YurtKayitDetays");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Veliler");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Veliler");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Veliler");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "TaksitOdemeleri");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "TaksitOdemeleri");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "TaksitOdemeleri");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Ogrenciler");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Ogrenciler");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Ogrenciler");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "OdemePlani");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "OdemePlani");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "OdemePlani");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Odalar");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Odalar");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Odalar");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Kullanicilar");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Kullanicilar");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Kullanicilar");

            migrationBuilder.AlterColumn<string>(
                name: "Taksit",
                table: "TaksitOdemeleri",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OdemeTarihi",
                table: "TaksitOdemeleri",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "YurtKayitMasters",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "YurtKayitMasters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "YurtKayitMasters",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "YurtKayitDetays",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "YurtKayitDetays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "YurtKayitDetays",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Veliler",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Veliler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Veliler",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Taksit",
                table: "TaksitOdemeleri",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OdemeTarihi",
                table: "TaksitOdemeleri",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "TaksitOdemeleri",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "TaksitOdemeleri",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "TaksitOdemeleri",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Ogrenciler",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Ogrenciler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Ogrenciler",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "OdemePlani",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "OdemePlani",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "OdemePlani",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Odalar",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Odalar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Odalar",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Kullanicilar",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Kullanicilar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Kullanicilar",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);
        }
    }
}
