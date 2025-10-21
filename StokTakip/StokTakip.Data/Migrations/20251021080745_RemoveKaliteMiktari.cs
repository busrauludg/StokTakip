using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StokTakip.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveKaliteMiktari : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KaliteMiktar",
                table: "StokDurumu");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StokKarti_PersonelId",
            //    table: "StokKarti",
            //    column: "PersonelId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_StokKarti_Personel_PersonelId",
            //    table: "StokKarti",
            //    column: "PersonelId",
            //    principalTable: "Personel",
            //    principalColumn: "PersonelId",
            //    onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
               name: "KaliteMiktar",
               table: "StokDurumu",
               type: "int",
               nullable: false,
               defaultValue: 0);

            //migrationBuilder.DropForeignKey(
            //    name: "FK_StokKarti_Personel_PersonelId",
            //    table: "StokKarti");

            //migrationBuilder.DropIndex(
            //    name: "IX_StokKarti_PersonelId",
            //    table: "StokKarti");

            //migrationBuilder.AddColumn<int>(
            //    name: "KaliteMiktar",
            //    table: "StokDurumu",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);
        }
    }
}
