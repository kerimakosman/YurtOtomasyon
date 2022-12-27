using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yurt.Entites.Migrations
{
    public partial class AddTaksit_TaksiOdeme_Tablo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KalanOdeme",
                table: "OdemePlani");

            migrationBuilder.DropColumn(
                name: "ToplamOdenen",
                table: "OdemePlani");

            migrationBuilder.CreateTable(
                name: "Taksitler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaksitSayisi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taksitler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaksitOdemeleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaksitId = table.Column<int>(type: "int", nullable: false),
                    OdemePlaniId = table.Column<int>(type: "int", nullable: false),
                    Tutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Odenen = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaksitOdemeleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaksitOdemeleri_OdemePlani_OdemePlaniId",
                        column: x => x.OdemePlaniId,
                        principalTable: "OdemePlani",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaksitOdemeleri_Taksitler_TaksitId",
                        column: x => x.TaksitId,
                        principalTable: "Taksitler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_TaksitOdemeleri_OdemePlaniId",
                table: "TaksitOdemeleri",
                column: "OdemePlaniId");

            migrationBuilder.CreateIndex(
                name: "IX_TaksitOdemeleri_TaksitId",
                table: "TaksitOdemeleri",
                column: "TaksitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaksitOdemeleri");

            migrationBuilder.DropTable(
                name: "Taksitler");

            migrationBuilder.AddColumn<decimal>(
                name: "KalanOdeme",
                table: "OdemePlani",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ToplamOdenen",
                table: "OdemePlani",
                type: "decimal(18,2)",
                nullable: true);
        }
    }
}
