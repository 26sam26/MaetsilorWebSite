using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Maetsilor.Data.Migrations
{
    public partial class _ajoutMessageSujet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sujets",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Auteur = table.Column<string>(nullable: true),
                    DateCréation = table.Column<DateTime>(nullable: false),
                    DernierRépondant = table.Column<string>(nullable: true),
                    DernièreRéponse = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    NbRéponse = table.Column<int>(nullable: false),
                    Titre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sujets", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Auteur = table.Column<string>(nullable: true),
                    SujetID = table.Column<int>(nullable: true),
                    Texte = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Messages_Sujets_SujetID",
                        column: x => x.SujetID,
                        principalTable: "Sujets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SujetID",
                table: "Messages",
                column: "SujetID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Sujets");
        }
    }
}
