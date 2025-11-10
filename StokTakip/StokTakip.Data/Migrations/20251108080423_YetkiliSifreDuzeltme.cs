using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StokTakip.Data.Migrations
{
    /// <inheritdoc />
    public partial class YetkiliSifreDuzeltme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Eski kolon varsa sil
            migrationBuilder.DropColumn(
                name: "YetkiliSifre",
                table: "Personel");

            // Yeni kolon ekle, nullable olacak
            migrationBuilder.AddColumn<string>(
                name: "YetkiliSifre1",
                table: "Personel",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Yeni kolonu sil
            migrationBuilder.DropColumn(
                name: "YetkiliSifre1",
                table: "Personel");

            // Eski kolon geri ekle (nullable değilse nullable ayarla)
            migrationBuilder.AddColumn<string>(
                name: "YetkiliSifre",
                table: "Personel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
