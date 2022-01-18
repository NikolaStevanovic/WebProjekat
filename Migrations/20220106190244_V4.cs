using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekat.Migrations
{
    public partial class V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KnjigeClanovi");

            migrationBuilder.AddColumn<int>(
                name: "ClanID",
                table: "Iznajmljivanje",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KnjigaID",
                table: "Iznajmljivanje",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MesecID",
                table: "Iznajmljivanje",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Iznajmljivanje_ClanID",
                table: "Iznajmljivanje",
                column: "ClanID");

            migrationBuilder.CreateIndex(
                name: "IX_Iznajmljivanje_KnjigaID",
                table: "Iznajmljivanje",
                column: "KnjigaID");

            migrationBuilder.CreateIndex(
                name: "IX_Iznajmljivanje_MesecID",
                table: "Iznajmljivanje",
                column: "MesecID");

            migrationBuilder.AddForeignKey(
                name: "FK_Iznajmljivanje_Clan_ClanID",
                table: "Iznajmljivanje",
                column: "ClanID",
                principalTable: "Clan",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Iznajmljivanje_Knjiga_KnjigaID",
                table: "Iznajmljivanje",
                column: "KnjigaID",
                principalTable: "Knjiga",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Iznajmljivanje_Mesec_MesecID",
                table: "Iznajmljivanje",
                column: "MesecID",
                principalTable: "Mesec",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Iznajmljivanje_Clan_ClanID",
                table: "Iznajmljivanje");

            migrationBuilder.DropForeignKey(
                name: "FK_Iznajmljivanje_Knjiga_KnjigaID",
                table: "Iznajmljivanje");

            migrationBuilder.DropForeignKey(
                name: "FK_Iznajmljivanje_Mesec_MesecID",
                table: "Iznajmljivanje");

            migrationBuilder.DropIndex(
                name: "IX_Iznajmljivanje_ClanID",
                table: "Iznajmljivanje");

            migrationBuilder.DropIndex(
                name: "IX_Iznajmljivanje_KnjigaID",
                table: "Iznajmljivanje");

            migrationBuilder.DropIndex(
                name: "IX_Iznajmljivanje_MesecID",
                table: "Iznajmljivanje");

            migrationBuilder.DropColumn(
                name: "ClanID",
                table: "Iznajmljivanje");

            migrationBuilder.DropColumn(
                name: "KnjigaID",
                table: "Iznajmljivanje");

            migrationBuilder.DropColumn(
                name: "MesecID",
                table: "Iznajmljivanje");

            migrationBuilder.CreateTable(
                name: "KnjigeClanovi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClanID = table.Column<int>(type: "int", nullable: true),
                    IznajmljivanjeID = table.Column<int>(type: "int", nullable: true),
                    KnjigaID = table.Column<int>(type: "int", nullable: true),
                    MesecID = table.Column<int>(type: "int", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_KnjigeClanovi_Mesec_MesecID",
                        column: x => x.MesecID,
                        principalTable: "Mesec",
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

            migrationBuilder.CreateIndex(
                name: "IX_KnjigeClanovi_MesecID",
                table: "KnjigeClanovi",
                column: "MesecID");
        }
    }
}
