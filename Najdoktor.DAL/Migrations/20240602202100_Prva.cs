using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Najdoktor.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Prva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gradovi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gradovi", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Specijalizacije",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivSpecijalizacije = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specijalizacije", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Bolnice",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bolnice", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Bolnice_Gradovi_GradID",
                        column: x => x.GradID,
                        principalTable: "Gradovi",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Pacijenti",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacijenti", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pacijenti_Gradovi_GradID",
                        column: x => x.GradID,
                        principalTable: "Gradovi",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Doktori",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecijalizacijaID = table.Column<int>(type: "int", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BolnicaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doktori", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Doktori_Bolnice_BolnicaID",
                        column: x => x.BolnicaID,
                        principalTable: "Bolnice",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doktori_Specijalizacije_SpecijalizacijaID",
                        column: x => x.SpecijalizacijaID,
                        principalTable: "Specijalizacije",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recenzije",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoktorID = table.Column<int>(type: "int", nullable: false),
                    PacijentID = table.Column<int>(type: "int", nullable: false),
                    Komentar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ocjena = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recenzije", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Recenzije_Doktori_DoktorID",
                        column: x => x.DoktorID,
                        principalTable: "Doktori",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recenzije_Pacijenti_PacijentID",
                        column: x => x.PacijentID,
                        principalTable: "Pacijenti",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Gradovi",
                columns: new[] { "ID", "Naziv" },
                values: new object[,]
                {
                    { 1, "Zagreb" },
                    { 2, "Velika Gorica" },
                    { 3, "Karlovac" },
                    { 4, "Rijeka" },
                    { 5, "Split" },
                    { 6, "Osijek" },
                    { 7, "Zadar" },
                    { 8, "Dubrovnik" },
                    { 9, "Pula" },
                    { 10, "Varaždin" },
                    { 11, "Čakovec" },
                    { 12, "Koprivnica" },
                    { 13, "Sisak" },
                    { 14, "Vrbovsko" }
                });

            migrationBuilder.InsertData(
                table: "Specijalizacije",
                columns: new[] { "ID", "NazivSpecijalizacije" },
                values: new object[,]
                {
                    { 1, "Opća medicina" },
                    { 2, "Dermatologija" },
                    { 3, "Oftalmologija" },
                    { 4, "Ortopedija" },
                    { 5, "Ginekologija" },
                    { 6, "Pedijatrija" },
                    { 7, "Kardiologija" },
                    { 8, "Neurologija" },
                    { 9, "Psihijatrija" },
                    { 10, "Radiologija" }
                });

            migrationBuilder.InsertData(
                table: "Bolnice",
                columns: new[] { "ID", "Adresa", "GradID", "Naziv" },
                values: new object[,]
                {
                    { 1, "Kišpatićeva 12", 1, "KBC Zagreb" },
                    { 2, "Krešimirova 42", 4, "KBC Rijeka" },
                    { 3, "Firule 12", 5, "KBC Split" },
                    { 4, "Josipa Huttlera 4", 6, "KBC Osijek" },
                    { 5, "Bože Peričića 5", 7, "OB Zadar" },
                    { 6, "Dr. Roka Mišetića 2", 8, "OB Dubrovnik" },
                    { 7, "Santoriova 24", 9, "OB Pula" },
                    { 8, "Ivana Meštrovića 1", 10, "OB Varaždin" },
                    { 9, "Ivana Gorana Kovačića 1E", 11, "ŽB Čakovec" },
                    { 10, "Andrije Štampara 3", 3, "OB Karlovac" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bolnice_GradID",
                table: "Bolnice",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Doktori_BolnicaID",
                table: "Doktori",
                column: "BolnicaID");

            migrationBuilder.CreateIndex(
                name: "IX_Doktori_SpecijalizacijaID",
                table: "Doktori",
                column: "SpecijalizacijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Pacijenti_GradID",
                table: "Pacijenti",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzije_DoktorID",
                table: "Recenzije",
                column: "DoktorID");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzije_PacijentID",
                table: "Recenzije",
                column: "PacijentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recenzije");

            migrationBuilder.DropTable(
                name: "Doktori");

            migrationBuilder.DropTable(
                name: "Pacijenti");

            migrationBuilder.DropTable(
                name: "Bolnice");

            migrationBuilder.DropTable(
                name: "Specijalizacije");

            migrationBuilder.DropTable(
                name: "Gradovi");
        }
    }
}
