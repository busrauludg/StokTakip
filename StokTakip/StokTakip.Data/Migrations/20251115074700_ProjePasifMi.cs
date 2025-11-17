using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StokTakip.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProjePasifMi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PasifMi",
                table: "Proje",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasifMi",
                table: "Proje");
        }
    }
}
