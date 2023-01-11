using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yurt.Entites.Migrations
{
    public partial class OdalardaDolulukBosYatakOlarakDegistirildi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Doluluk",
                table: "Odalar",
                newName: "BosYatak");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BosYatak",
                table: "Odalar",
                newName: "Doluluk");
        }
    }
}
