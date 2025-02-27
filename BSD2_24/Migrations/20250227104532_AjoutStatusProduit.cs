using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSD2_24.Migrations
{
    /// <inheritdoc />
    public partial class AjoutStatusProduit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Produit",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Produit");
        }
    }
}
