using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CsaludApp.Web.Migrations
{
    public partial class CompleteDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Document = table.Column<string>(maxLength: 30, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    CellPhone = table.Column<string>(maxLength: 20, nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    Born = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    PatientId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Consents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    PatientId = table.Column<int>(nullable: true),
                    DentistId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consents_Dentists_DentistId",
                        column: x => x.DentistId,
                        principalTable: "Dentists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Consents_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Diagnoses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodeDx = table.Column<string>(maxLength: 10, nullable: false),
                    NameDx = table.Column<string>(maxLength: 200, nullable: false),
                    ConsentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnoses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diagnoses_Consents_ConsentId",
                        column: x => x.ConsentId,
                        principalTable: "Consents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Processes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodePx = table.Column<string>(maxLength: 10, nullable: false),
                    NamePx = table.Column<string>(maxLength: 200, nullable: false),
                    ConsentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Processes_Consents_ConsentId",
                        column: x => x.ConsentId,
                        principalTable: "Consents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consents_DentistId",
                table: "Consents",
                column: "DentistId");

            migrationBuilder.CreateIndex(
                name: "IX_Consents_PatientId",
                table: "Consents",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnoses_ConsentId",
                table: "Diagnoses",
                column: "ConsentId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_PatientId",
                table: "Patients",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Processes_ConsentId",
                table: "Processes",
                column: "ConsentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diagnoses");

            migrationBuilder.DropTable(
                name: "Processes");

            migrationBuilder.DropTable(
                name: "Consents");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
