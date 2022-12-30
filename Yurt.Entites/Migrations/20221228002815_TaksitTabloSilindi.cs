using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yurt.Entites.Migrations
{
    public partial class TaksitTabloSilindi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaksitOdemeleri_Taksitler_TaksitId",
                table: "TaksitOdemeleri");

            migrationBuilder.DropTable(
                name: "Taksitler");

            migrationBuilder.DropIndex(
                name: "IX_TaksitOdemeleri_TaksitId",
                table: "TaksitOdemeleri");

            migrationBuilder.DropColumn(
                name: "TaksitId",
                table: "TaksitOdemeleri");

            migrationBuilder.AddColumn<string>(
                name: "Taksit",
                table: "TaksitOdemeleri",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Taksit",
                table: "TaksitOdemeleri");

            migrationBuilder.AddColumn<int>(
                name: "TaksitId",
                table: "TaksitOdemeleri",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Taksitler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TaksitSayisi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taksitler", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Taksitler",
                columns: new[] { "Id", "CreateDate", "DeleteDate", "Status", "TaksitSayisi", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 12, 27, 22, 56, 56, 673, DateTimeKind.Local).AddTicks(6442), null, 1, "1.Taksit", null },
                    { 2, new DateTime(2022, 12, 27, 22, 56, 56, 673, DateTimeKind.Local).AddTicks(6455), null, 1, "2.Taksit", null },
                    { 3, new DateTime(2022, 12, 27, 22, 56, 56, 673, DateTimeKind.Local).AddTicks(6457), null, 1, "3.Taksit", null },
                    { 4, new DateTime(2022, 12, 27, 22, 56, 56, 673, DateTimeKind.Local).AddTicks(6462), null, 1, "4.Taksit", null },
                    { 5, new DateTime(2022, 12, 27, 22, 56, 56, 673, DateTimeKind.Local).AddTicks(6464), null, 1, "5.Taksit", null },
                    { 6, new DateTime(2022, 12, 27, 22, 56, 56, 673, DateTimeKind.Local).AddTicks(6466), null, 1, "6.Taksit", null },
                    { 7, new DateTime(2022, 12, 27, 22, 56, 56, 673, DateTimeKind.Local).AddTicks(6469), null, 1, "7.Taksit", null },
                    { 8, new DateTime(2022, 12, 27, 22, 56, 56, 673, DateTimeKind.Local).AddTicks(6471), null, 1, "8.Taksit", null },
                    { 9, new DateTime(2022, 12, 27, 22, 56, 56, 673, DateTimeKind.Local).AddTicks(6473), null, 1, "9.Taksit", null },
                    { 10, new DateTime(2022, 12, 27, 22, 56, 56, 673, DateTimeKind.Local).AddTicks(6476), null, 1, "10.Taksit", null },
                    { 11, new DateTime(2022, 12, 27, 22, 56, 56, 673, DateTimeKind.Local).AddTicks(6479), null, 1, "11.Taksit", null },
                    { 12, new DateTime(2022, 12, 27, 22, 56, 56, 673, DateTimeKind.Local).AddTicks(6481), null, 1, "12.Taksit", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaksitOdemeleri_TaksitId",
                table: "TaksitOdemeleri",
                column: "TaksitId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaksitOdemeleri_Taksitler_TaksitId",
                table: "TaksitOdemeleri",
                column: "TaksitId",
                principalTable: "Taksitler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
