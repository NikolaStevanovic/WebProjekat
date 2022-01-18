using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekat.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clan",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClanskaKarta = table.Column<int>(type: "int", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clan", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Iznajmljivanje",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mesec = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iznajmljivanje", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Knjiga",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sifra = table.Column<int>(type: "int", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Zanr = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Knjiga", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KnjigeClanovi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClanID = table.Column<int>(type: "int", nullable: true),
                    KnjigaID = table.Column<int>(type: "int", nullable: true),
                    IznajmljivanjeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnjigeClanovi", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KnjigeClanovi_Clan_ClanID",
                        column: x => x.ClanID,
                        principalTable: "Clan",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KnjigeClanovi_Iznajmljivanje_IznajmljivanjeID",
                        column: x => x.IznajmljivanjeID,
                        principalTable: "Iznajmljivanje",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KnjigeClanovi_Knjiga_KnjigaID",
                        column: x => x.KnjigaID,
                        principalTable: "Knjiga",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KnjigeClanovi_ClanID",
                table: "KnjigeClanovi",
                column: "ClanID");

            migrationBuilder.CreateIndex(
                name: "IX_KnjigeClanovi_IznajmljivanjeID",
                table: "KnjigeClanovi",
                column: "IznajmljivanjeID");

            migrationBuilder.CreateIndex(
                name: "IX_KnjigeClanovi_KnjigaID",
                table: "KnjigeClanovi",
                column: "KnjigaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KnjigeClanovi");

            migrationBuilder.DropTable(
                name: "Clan");

            migrationBuilder.DropTable(
                name: "Iznajmljivanje");

            migrationBuilder.DropTable(
                name: "Knjiga");
        }
    }
}
