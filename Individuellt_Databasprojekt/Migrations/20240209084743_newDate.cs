using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Individuellt_Databasprojekt.Migrations
{
    public partial class newDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblBetyg",
                columns: table => new
                {
                    BetygID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Betyg = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Betygpoäng = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblBetyg__E90ED0485A35972D", x => x.BetygID);
                });

            migrationBuilder.CreateTable(
                name: "tblKlasser",
                columns: table => new
                {
                    KlassID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KlassNamn = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Klasser__CF47A60D33E6B237", x => x.KlassID);
                });

            migrationBuilder.CreateTable(
                name: "tblKurs",
                columns: table => new
                {
                    kurskodNy = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kursnamn = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Poäng = table.Column<int>(type: "int", nullable: true),
                    Kursstart = table.Column<DateTime>(type: "date", nullable: true),
                    kursslut = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblKurs", x => x.kurskodNy);
                });

            migrationBuilder.CreateTable(
                name: "tblTitlar",
                columns: table => new
                {
                    TitelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titel = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Titlar__6E58D659325B3EA8", x => x.TitelID);
                });

            migrationBuilder.CreateTable(
                name: "tblStudent",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Personnummer = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: true),
                    Förnamn = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Efternamn = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Klass = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblStudent", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_tblStudent_tblKlasser",
                        column: x => x.Klass,
                        principalTable: "tblKlasser",
                        principalColumn: "KlassID");
                });

            migrationBuilder.CreateTable(
                name: "tblPersonal",
                columns: table => new
                {
                    PersonalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Förnamn = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Efternamn = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Titel = table.Column<int>(type: "int", nullable: true),
                    Lön = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StartDatum = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblPerso__28343713BC340614", x => x.PersonalID);
                    table.ForeignKey(
                        name: "FK_tblPersonal_Titlar",
                        column: x => x.Titel,
                        principalTable: "tblTitlar",
                        principalColumn: "TitelID");
                });

            migrationBuilder.CreateTable(
                name: "KStudenterIKurser",
                columns: table => new
                {
                    kurskodNY = table.Column<int>(type: "int", nullable: true),
                    StudentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_KStudenterIKurser_tblKurs",
                        column: x => x.kurskodNY,
                        principalTable: "tblKurs",
                        principalColumn: "kurskodNy");
                    table.ForeignKey(
                        name: "FK_KStudenterIKurser_tblStudent1",
                        column: x => x.StudentID,
                        principalTable: "tblStudent",
                        principalColumn: "StudentID");
                });

            migrationBuilder.CreateTable(
                name: "KPersonalHarKurs",
                columns: table => new
                {
                    PersonalID = table.Column<int>(type: "int", nullable: true),
                    KurskodNY = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_KPersonalHarKurs_tblKurs",
                        column: x => x.KurskodNY,
                        principalTable: "tblKurs",
                        principalColumn: "kurskodNy");
                    table.ForeignKey(
                        name: "FK_KPersonalHarKurs_tblPersonal",
                        column: x => x.PersonalID,
                        principalTable: "tblPersonal",
                        principalColumn: "PersonalID");
                });

            migrationBuilder.CreateTable(
                name: "KSattaBetyg",
                columns: table => new
                {
                    BetygID = table.Column<int>(type: "int", nullable: true),
                    Betygsdatum = table.Column<DateTime>(type: "date", nullable: true),
                    personalID = table.Column<int>(type: "int", nullable: true),
                    kurskodNY = table.Column<int>(type: "int", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_KSattaBetyg_tblBetyg",
                        column: x => x.BetygID,
                        principalTable: "tblBetyg",
                        principalColumn: "BetygID");
                    table.ForeignKey(
                        name: "FK_KSattaBetyg_tblKurs",
                        column: x => x.kurskodNY,
                        principalTable: "tblKurs",
                        principalColumn: "kurskodNy");
                    table.ForeignKey(
                        name: "FK_KSattaBetyg_tblPersonal",
                        column: x => x.personalID,
                        principalTable: "tblPersonal",
                        principalColumn: "PersonalID");
                    table.ForeignKey(
                        name: "FK_KSattaBetyg_tblStudent",
                        column: x => x.StudentId,
                        principalTable: "tblStudent",
                        principalColumn: "StudentID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_KPersonalHarKurs_KurskodNY",
                table: "KPersonalHarKurs",
                column: "KurskodNY");

            migrationBuilder.CreateIndex(
                name: "IX_KPersonalHarKurs_PersonalID",
                table: "KPersonalHarKurs",
                column: "PersonalID");

            migrationBuilder.CreateIndex(
                name: "IX_KSattaBetyg_BetygID",
                table: "KSattaBetyg",
                column: "BetygID");

            migrationBuilder.CreateIndex(
                name: "IX_KSattaBetyg_kurskodNY",
                table: "KSattaBetyg",
                column: "kurskodNY");

            migrationBuilder.CreateIndex(
                name: "IX_KSattaBetyg_personalID",
                table: "KSattaBetyg",
                column: "personalID");

            migrationBuilder.CreateIndex(
                name: "IX_KSattaBetyg_StudentId",
                table: "KSattaBetyg",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_KStudenterIKurser_kurskodNY",
                table: "KStudenterIKurser",
                column: "kurskodNY");

            migrationBuilder.CreateIndex(
                name: "IX_KStudenterIKurser_StudentID",
                table: "KStudenterIKurser",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_tblPersonal_Titel",
                table: "tblPersonal",
                column: "Titel");

            migrationBuilder.CreateIndex(
                name: "IX_tblStudent_Klass",
                table: "tblStudent",
                column: "Klass");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KPersonalHarKurs");

            migrationBuilder.DropTable(
                name: "KSattaBetyg");

            migrationBuilder.DropTable(
                name: "KStudenterIKurser");

            migrationBuilder.DropTable(
                name: "tblBetyg");

            migrationBuilder.DropTable(
                name: "tblPersonal");

            migrationBuilder.DropTable(
                name: "tblKurs");

            migrationBuilder.DropTable(
                name: "tblStudent");

            migrationBuilder.DropTable(
                name: "tblTitlar");

            migrationBuilder.DropTable(
                name: "tblKlasser");
        }
    }
}
