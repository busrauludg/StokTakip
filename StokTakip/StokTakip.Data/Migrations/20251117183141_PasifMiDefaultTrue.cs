using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StokTakip.Data.Migrations
{
    /// <inheritdoc />
    public partial class PasifMiDefaultTrue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
               name: "PasifMi",
               table: "Proje",
               type: "bit",
               nullable: false,
               defaultValue: true,  // artık default true
               oldClrType: typeof(bool),
               oldType: "bit",
               oldDefaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "PasifMi",
                table: "Proje",
                type: "bit",
                nullable: false,
                defaultValue: false, // geri alırken eski değer
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);
        }
    }
}
