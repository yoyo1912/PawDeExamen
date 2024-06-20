using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RedoPawProj.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DomeniiActivitate",
                columns: new[] { "Id", "Descriere", "Nume" },
                values: new object[,]
                {
                    { 1, "Information Technology", "IT" },
                    { 2, "Human Resources", "HR" }
                });

            migrationBuilder.InsertData(
                table: "Companii",
                columns: new[] { "Id", "Adresa", "DataInfiintarii", "DomeniuActivitateId", "NumarTelefon", "Nume" },
                values: new object[,]
                {
                    { 1, "123 Main St", new DateTime(2024, 6, 21, 0, 58, 47, 309, DateTimeKind.Local).AddTicks(9410), 1, "123456789", "Company A" },
                    { 2, "456 Side St", new DateTime(2024, 6, 21, 0, 58, 47, 309, DateTimeKind.Local).AddTicks(9449), 2, "987654321", "Company B" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companii",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companii",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DomeniiActivitate",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DomeniiActivitate",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
