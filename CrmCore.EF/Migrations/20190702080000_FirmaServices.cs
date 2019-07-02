using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrmCore.EF.Migrations
{
    public partial class FirmaServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adres",
                table: "Firmalar",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EPosta",
                table: "Firmalar",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FaturaAdresi",
                table: "Firmalar",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefon",
                table: "Firmalar",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WebSitesi",
                table: "Firmalar",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FirmaKontaklar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdiSoyadi = table.Column<string>(nullable: false),
                    Telefon = table.Column<string>(nullable: true),
                    EPosta = table.Column<string>(nullable: true),
                    FirmaId = table.Column<int>(nullable: false),
                    CreatorUserId = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirmaKontaklar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FirmaKontaklar_Firmalar_FirmaId",
                        column: x => x.FirmaId,
                        principalTable: "Firmalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Gorusmeler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Konu = table.Column<string>(nullable: true),
                    Detay = table.Column<string>(nullable: true),
                    FirmaId = table.Column<int>(nullable: false),
                    FirmaKontakId = table.Column<int>(nullable: false),
                    CreatorUserId = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gorusmeler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gorusmeler_Firmalar_FirmaId",
                        column: x => x.FirmaId,
                        principalTable: "Firmalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Gorusmeler_FirmaKontaklar_FirmaKontakId",
                        column: x => x.FirmaKontakId,
                        principalTable: "FirmaKontaklar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FirmaKontaklar_FirmaId",
                table: "FirmaKontaklar",
                column: "FirmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Gorusmeler_FirmaId",
                table: "Gorusmeler",
                column: "FirmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Gorusmeler_FirmaKontakId",
                table: "Gorusmeler",
                column: "FirmaKontakId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gorusmeler");

            migrationBuilder.DropTable(
                name: "FirmaKontaklar");

            migrationBuilder.DropColumn(
                name: "Adres",
                table: "Firmalar");

            migrationBuilder.DropColumn(
                name: "EPosta",
                table: "Firmalar");

            migrationBuilder.DropColumn(
                name: "FaturaAdresi",
                table: "Firmalar");

            migrationBuilder.DropColumn(
                name: "Telefon",
                table: "Firmalar");

            migrationBuilder.DropColumn(
                name: "WebSitesi",
                table: "Firmalar");
        }
    }
}
