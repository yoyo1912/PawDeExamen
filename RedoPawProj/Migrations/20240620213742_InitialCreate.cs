using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedoPawProj.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DomeniiActivitate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descriere = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomeniiActivitate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companii",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumarTelefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataInfiintarii = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DomeniuActivitateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companii", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companii_DomeniiActivitate_DomeniuActivitateId",
                        column: x => x.DomeniuActivitateId,
                        principalTable: "DomeniiActivitate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companii_DomeniuActivitateId",
                table: "Companii",
                column: "DomeniuActivitateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companii");

            migrationBuilder.DropTable(
                name: "DomeniiActivitate");
        }
    }
}
