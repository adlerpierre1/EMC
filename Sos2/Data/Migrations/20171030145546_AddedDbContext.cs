using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Sos2.Data.Migrations
{
    public partial class AddedDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AfterMaths",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WTDA = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AfterMaths", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Preparations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WTDB = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preparations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DisasterTable",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AftermathID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrepID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisasterTable", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DisasterTable_AfterMaths_AftermathID",
                        column: x => x.AftermathID,
                        principalTable: "AfterMaths",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DisasterTable_Preparations_PrepID",
                        column: x => x.PrepID,
                        principalTable: "Preparations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BasicTable",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DisasterID = table.Column<int>(type: "int", nullable: true),
                    What = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    When = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Where = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicTable", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BasicTable_DisasterTable_DisasterID",
                        column: x => x.DisasterID,
                        principalTable: "DisasterTable",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasicTable_DisasterID",
                table: "BasicTable",
                column: "DisasterID");

            migrationBuilder.CreateIndex(
                name: "IX_DisasterTable_AftermathID",
                table: "DisasterTable",
                column: "AftermathID");

            migrationBuilder.CreateIndex(
                name: "IX_DisasterTable_PrepID",
                table: "DisasterTable",
                column: "PrepID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasicTable");

            migrationBuilder.DropTable(
                name: "DisasterTable");

            migrationBuilder.DropTable(
                name: "AfterMaths");

            migrationBuilder.DropTable(
                name: "Preparations");
        }
    }
}
