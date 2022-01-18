using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekat.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Zanr",
                table: "Knjiga");

            migrationBuilder.AddColumn<int>(
                name: "MesecID",
                table: "KnjigeClanovi",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ZanrID",
                table: "Knjiga",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Mesec",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesec", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Zanr",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zanr", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KnjigeClanovi_MesecID",
                table: "KnjigeClanovi",
                column: "MesecID");

            migrationBuilder.CreateIndex(
                name: "IX_Knjiga_ZanrID",
                table: "Knjiga",
                column: "ZanrID");

            migrationBuilder.AddForeignKey(
                name: "FK_Knjiga_Zanr_ZanrID",
                table: "Knjiga",
                column: "ZanrID",
                principalTable: "Zanr",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KnjigeClanovi_Mesec_MesecID",
                table: "KnjigeClanovi",
                column: "MesecID",
                principalTable: "Mesec",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Knjiga_Zanr_ZanrID",
                table: "Knjiga");

            migrationBuilder.DropForeignKey(
                name: "FK_KnjigeClanovi_Mesec_MesecID",
                table: "KnjigeClanovi");

            migrationBuilder.DropTable(
                name: "Mesec");

            migrationBuilder.DropTable(
                name: "Zanr");

            migrationBuilder.DropIndex(
                name: "IX_KnjigeClanovi_MesecID",
                table: "KnjigeClanovi");

            migrationBuilder.DropIndex(
                name: "IX_Knjiga_ZanrID",
                table: "Knjiga");

            migrationBuilder.DropColumn(
                name: "MesecID",
                table: "KnjigeClanovi");

            migrationBuilder.DropColumn(
                name: "ZanrID",
                table: "Knjiga");

            migrationBuilder.AddColumn<string>(
                name: "Zanr",
                table: "Knjiga",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }
    }
}
