using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yurt.Entites.Migrations
{
    public partial class OdaTablosunaDolulukveCinsiyetEklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "Doluluk",
                table: "Odalar",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<bool>(
                name: "OdaCinsiyet",
                table: "Odalar",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Doluluk",
                table: "Odalar");

            migrationBuilder.DropColumn(
                name: "OdaCinsiyet",
                table: "Odalar");
        }
    }
}
