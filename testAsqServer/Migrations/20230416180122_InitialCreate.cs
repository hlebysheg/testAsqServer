using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testAsqServer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Path = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    hash = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayForm",
                columns: table => new
                {
                    Bik = table.Column<string>(type: "TEXT", nullable: false),
                    BankName = table.Column<string>(type: "TEXT", nullable: false),
                    CheckingAccount = table.Column<string>(type: "TEXT", nullable: false),
                    CorrespondentAccount = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayForm", x => x.Bik);
                });

            migrationBuilder.CreateTable(
                name: "StandartIPForm",
                columns: table => new
                {
                    Inn = table.Column<string>(type: "TEXT", nullable: false),
                    InnFileId = table.Column<int>(type: "INTEGER", nullable: false),
                    Ogrip = table.Column<string>(type: "TEXT", nullable: false),
                    OgripFileId = table.Column<int>(type: "INTEGER", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EgripFileId = table.Column<int>(type: "INTEGER", nullable: false),
                    RentFileId = table.Column<int>(type: "INTEGER", nullable: true),
                    PayFormId = table.Column<int>(type: "INTEGER", nullable: false),
                    PayFormBik = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandartIPForm", x => x.Inn);
                    table.ForeignKey(
                        name: "FK_StandartIPForm_FileInfo_EgripFileId",
                        column: x => x.EgripFileId,
                        principalTable: "FileInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StandartIPForm_FileInfo_InnFileId",
                        column: x => x.InnFileId,
                        principalTable: "FileInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StandartIPForm_FileInfo_OgripFileId",
                        column: x => x.OgripFileId,
                        principalTable: "FileInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StandartIPForm_FileInfo_RentFileId",
                        column: x => x.RentFileId,
                        principalTable: "FileInfo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StandartIPForm_PayForm_PayFormBik",
                        column: x => x.PayFormBik,
                        principalTable: "PayForm",
                        principalColumn: "Bik",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OOOForm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrganisationFullName = table.Column<string>(type: "TEXT", nullable: true),
                    OrganisationShortName = table.Column<string>(type: "TEXT", nullable: true),
                    Date = table.Column<string>(type: "TEXT", nullable: true),
                    StandartIPFormId = table.Column<int>(type: "INTEGER", nullable: false),
                    StandartIPFormInn = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OOOForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OOOForm_StandartIPForm_StandartIPFormInn",
                        column: x => x.StandartIPFormInn,
                        principalTable: "StandartIPForm",
                        principalColumn: "Inn",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OOOForm_StandartIPFormInn",
                table: "OOOForm",
                column: "StandartIPFormInn");

            migrationBuilder.CreateIndex(
                name: "IX_StandartIPForm_EgripFileId",
                table: "StandartIPForm",
                column: "EgripFileId");

            migrationBuilder.CreateIndex(
                name: "IX_StandartIPForm_InnFileId",
                table: "StandartIPForm",
                column: "InnFileId");

            migrationBuilder.CreateIndex(
                name: "IX_StandartIPForm_OgripFileId",
                table: "StandartIPForm",
                column: "OgripFileId");

            migrationBuilder.CreateIndex(
                name: "IX_StandartIPForm_PayFormBik",
                table: "StandartIPForm",
                column: "PayFormBik");

            migrationBuilder.CreateIndex(
                name: "IX_StandartIPForm_RentFileId",
                table: "StandartIPForm",
                column: "RentFileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OOOForm");

            migrationBuilder.DropTable(
                name: "StandartIPForm");

            migrationBuilder.DropTable(
                name: "FileInfo");

            migrationBuilder.DropTable(
                name: "PayForm");
        }
    }
}
