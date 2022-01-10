using Microsoft.EntityFrameworkCore.Migrations;

namespace ProiectASP.Migrations
{
    public partial class CreareTabele : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Angajati",
                columns: table => new
                {
                    IdAngajat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Prenume = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Salariu = table.Column<int>(type: "int", nullable: false),
                    Job = table.Column<string>(type: "nvarchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Angajati", x => x.IdAngajat);
                });

            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    IdCategorie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(60)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.IdCategorie);
                });

            migrationBuilder.CreateTable(
                name: "Clienti",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Prenume = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clienti", x => x.IdClient);
                });

            migrationBuilder.CreateTable(
                name: "Filament",
                columns: table => new
                {
                    IdFilament = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipFilament = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    TemperaturaTopire = table.Column<float>(type: "real", nullable: false),
                    Gramaj = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filament", x => x.IdFilament);
                });

            migrationBuilder.CreateTable(
                name: "Imprimante",
                columns: table => new
                {
                    IdImprimanta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(60)", nullable: true),
                    DimensiunePat = table.Column<float>(type: "real", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imprimante", x => x.IdImprimanta);
                });

            migrationBuilder.CreateTable(
                name: "Adrese",
                columns: table => new
                {
                    IdAdresa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Oras = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Strada = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    IdAngajat = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adrese", x => x.IdAdresa);
                    table.ForeignKey(
                        name: "FK_Adrese_Angajati_IdAngajat",
                        column: x => x.IdAngajat,
                        principalTable: "Angajati",
                        principalColumn: "IdAngajat",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comenzi",
                columns: table => new
                {
                    IdComanda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Valoare = table.Column<float>(type: "real", nullable: false),
                    StatusTotal = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    ClientiIdClient = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comenzi", x => x.IdComanda);
                    table.ForeignKey(
                        name: "FK_Comenzi_Clienti_ClientiIdClient",
                        column: x => x.ClientiIdClient,
                        principalTable: "Clienti",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Produse",
                columns: table => new
                {
                    IdProdus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    PretVanzare = table.Column<float>(type: "real", nullable: false),
                    CostProducere = table.Column<float>(type: "real", nullable: false),
                    CantitateFilament = table.Column<float>(type: "real", nullable: false),
                    Dimensiune = table.Column<float>(type: "real", nullable: false),
                    CategorieIdCategorie = table.Column<int>(type: "int", nullable: true),
                    FilamentIdFilament = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produse", x => x.IdProdus);
                    table.ForeignKey(
                        name: "FK_Produse_Categorie_CategorieIdCategorie",
                        column: x => x.CategorieIdCategorie,
                        principalTable: "Categorie",
                        principalColumn: "IdCategorie",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Produse_Filament_FilamentIdFilament",
                        column: x => x.FilamentIdFilament,
                        principalTable: "Filament",
                        principalColumn: "IdFilament",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImprimanteFilament",
                columns: table => new
                {
                    IdFilament = table.Column<int>(type: "int", nullable: false),
                    IdImprimanta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImprimanteFilament", x => new { x.IdFilament, x.IdImprimanta });
                    table.ForeignKey(
                        name: "FK_ImprimanteFilament_Filament_IdFilament",
                        column: x => x.IdFilament,
                        principalTable: "Filament",
                        principalColumn: "IdFilament",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImprimanteFilament_Imprimante_IdImprimanta",
                        column: x => x.IdImprimanta,
                        principalTable: "Imprimante",
                        principalColumn: "IdImprimanta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetaliiComanda",
                columns: table => new
                {
                    IdComanda = table.Column<int>(type: "int", nullable: false),
                    IdProdus = table.Column<int>(type: "int", nullable: false),
                    IdProiectant = table.Column<int>(type: "int", nullable: false),
                    IdExecutant = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetaliiComanda", x => new { x.IdComanda, x.IdProdus });
                    table.ForeignKey(
                        name: "FK_DetaliiComanda_Angajati_IdProiectant",
                        column: x => x.IdProiectant,
                        principalTable: "Angajati",
                        principalColumn: "IdAngajat",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetaliiComanda_Comenzi_IdComanda",
                        column: x => x.IdComanda,
                        principalTable: "Comenzi",
                        principalColumn: "IdComanda",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetaliiComanda_Produse_IdProdus",
                        column: x => x.IdProdus,
                        principalTable: "Produse",
                        principalColumn: "IdProdus",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adrese_IdAngajat",
                table: "Adrese",
                column: "IdAngajat",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comenzi_ClientiIdClient",
                table: "Comenzi",
                column: "ClientiIdClient");

            migrationBuilder.CreateIndex(
                name: "IX_DetaliiComanda_IdProdus",
                table: "DetaliiComanda",
                column: "IdProdus");

            migrationBuilder.CreateIndex(
                name: "IX_DetaliiComanda_IdProiectant",
                table: "DetaliiComanda",
                column: "IdProiectant");

            migrationBuilder.CreateIndex(
                name: "IX_ImprimanteFilament_IdImprimanta",
                table: "ImprimanteFilament",
                column: "IdImprimanta");

            migrationBuilder.CreateIndex(
                name: "IX_Produse_CategorieIdCategorie",
                table: "Produse",
                column: "CategorieIdCategorie");

            migrationBuilder.CreateIndex(
                name: "IX_Produse_FilamentIdFilament",
                table: "Produse",
                column: "FilamentIdFilament");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adrese");

            migrationBuilder.DropTable(
                name: "DetaliiComanda");

            migrationBuilder.DropTable(
                name: "ImprimanteFilament");

            migrationBuilder.DropTable(
                name: "Angajati");

            migrationBuilder.DropTable(
                name: "Comenzi");

            migrationBuilder.DropTable(
                name: "Produse");

            migrationBuilder.DropTable(
                name: "Imprimante");

            migrationBuilder.DropTable(
                name: "Clienti");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropTable(
                name: "Filament");
        }
    }
}
