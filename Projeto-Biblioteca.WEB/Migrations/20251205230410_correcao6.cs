using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Biblioteca.WEB.Migrations
{
    /// <inheritdoc />
    public partial class correcao6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome_Produto",
                table: "Produto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome_Produto",
                table: "Produto");
        }
    }
}
