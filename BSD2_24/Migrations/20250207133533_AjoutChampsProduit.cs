using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSD2_24.Migrations
{
    /// <inheritdoc />
    public partial class AjoutChampsProduit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeSortie",
                table: "Produit",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Prix",
                table: "Produit",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateDeSortie",
                table: "Produit");

            migrationBuilder.DropColumn(
                name: "Prix",
                table: "Produit");
        }
    }
}
