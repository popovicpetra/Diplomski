using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiplomskiBackend.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Editor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Izdanje",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BrojIzdanja = table.Column<int>(type: "int", nullable: false),
                    Cena = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Izdanje", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lektor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lektor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TehnickiSaradnik",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TehnickiSaradnik", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TehnickiSekretar",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TehnickiSekretar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TehnickiUredniks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TehnickiUredniks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rad",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IzdanjeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EditorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TehnickiUrednikId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LektorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TehnickiSekretarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TehnickiSaradnikId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rad_Editor_EditorId",
                        column: x => x.EditorId,
                        principalTable: "Editor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rad_Izdanje_IzdanjeId",
                        column: x => x.IzdanjeId,
                        principalTable: "Izdanje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rad_Lektor_LektorId",
                        column: x => x.LektorId,
                        principalTable: "Lektor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rad_TehnickiSaradnik_TehnickiSaradnikId",
                        column: x => x.TehnickiSaradnikId,
                        principalTable: "TehnickiSaradnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rad_TehnickiSekretar_TehnickiSekretarId",
                        column: x => x.TehnickiSekretarId,
                        principalTable: "TehnickiSekretar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rad_TehnickiUredniks_TehnickiUrednikId",
                        column: x => x.TehnickiUrednikId,
                        principalTable: "TehnickiUredniks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rad_EditorId",
                table: "Rad",
                column: "EditorId");

            migrationBuilder.CreateIndex(
                name: "IX_Rad_IzdanjeId",
                table: "Rad",
                column: "IzdanjeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rad_LektorId",
                table: "Rad",
                column: "LektorId");

            migrationBuilder.CreateIndex(
                name: "IX_Rad_TehnickiSaradnikId",
                table: "Rad",
                column: "TehnickiSaradnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Rad_TehnickiSekretarId",
                table: "Rad",
                column: "TehnickiSekretarId");

            migrationBuilder.CreateIndex(
                name: "IX_Rad_TehnickiUrednikId",
                table: "Rad",
                column: "TehnickiUrednikId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rad");

            migrationBuilder.DropTable(
                name: "Editor");

            migrationBuilder.DropTable(
                name: "Izdanje");

            migrationBuilder.DropTable(
                name: "Lektor");

            migrationBuilder.DropTable(
                name: "TehnickiSaradnik");

            migrationBuilder.DropTable(
                name: "TehnickiSekretar");

            migrationBuilder.DropTable(
                name: "TehnickiUredniks");
        }
    }
}
