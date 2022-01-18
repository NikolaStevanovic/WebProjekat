using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekat.Migrations
{
    public partial class V5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BibliotekaID",
                table: "Knjiga",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BibliotekaID",
                table: "Iznajmljivanje",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BibliotekaID",
                table: "Clan",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Biblioteka",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biblioteka", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Knjiga_BibliotekaID",
                table: "Knjiga",
                column: "BibliotekaID");

            migrationBuilder.CreateIndex(
                name: "IX_Iznajmljivanje_BibliotekaID",
                table: "Iznajmljivanje",
                column: "BibliotekaID");

            migrationBuilder.CreateIndex(
                name: "IX_Clan_BibliotekaID",
                table: "Clan",
                column: "BibliotekaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clan_Biblioteka_BibliotekaID",
                table: "Clan",
                column: "BibliotekaID",
                principalTable: "Biblioteka",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Iznajmljivanje_Biblioteka_BibliotekaID",
                table: "Iznajmljivanje",
                column: "BibliotekaID",
                principalTable: "Biblioteka",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Knjiga_Biblioteka_BibliotekaID",
                table: "Knjiga",
                column: "BibliotekaID",
                principalTable: "Biblioteka",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clan_Biblioteka_BibliotekaID",
                table: "Clan");

            migrationBuilder.DropForeignKey(
                name: "FK_Iznajmljivanje_Biblioteka_BibliotekaID",
                table: "Iznajmljivanje");

            migrationBuilder.DropForeignKey(
                name: "FK_Knjiga_Biblioteka_BibliotekaID",
                table: "Knjiga");

            migrationBuilder.DropTable(
                name: "Biblioteka");

            migrationBuilder.DropIndex(
                name: "IX_Knjiga_BibliotekaID",
                table: "Knjiga");

            migrationBuilder.DropIndex(
                name: "IX_Iznajmljivanje_BibliotekaID",
                table: "Iznajmljivanje");

            migrationBuilder.DropIndex(
                name: "IX_Clan_BibliotekaID",
                table: "Clan");

            migrationBuilder.DropColumn(
                name: "BibliotekaID",
                table: "Knjiga");

            migrationBuilder.DropColumn(
                name: "BibliotekaID",
                table: "Iznajmljivanje");

            migrationBuilder.DropColumn(
                name: "BibliotekaID",
                table: "Clan");
        }
    }
}
