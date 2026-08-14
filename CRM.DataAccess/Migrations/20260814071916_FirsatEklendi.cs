using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FirsatEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Firsatlar",
                columns: table => new
                {
                    FirsatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusteriId = table.Column<int>(type: "int", nullable: false),
                    FirsatBasligi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TahminiTutar = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FirsatDurumu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kaynak = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SorumluKullaniciId = table.Column<int>(type: "int", nullable: false),
                    BeklenenKapanisTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firsatlar", x => x.FirsatId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Firsatlar");
        }
    }
}
