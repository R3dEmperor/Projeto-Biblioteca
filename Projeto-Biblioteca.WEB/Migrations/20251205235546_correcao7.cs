using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Biblioteca.WEB.Migrations
{
    /// <inheritdoc />
    public partial class correcao7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
            name: "CPF_Usuario",
            table: "Usuario",
            type: "nvarchar(50)",
            maxLength: 50,
            nullable: false,
            defaultValue: "");

            migrationBuilder.AddColumn<string>(
            name: "Telefone_Usuario",
            table: "Usuario",
            type: "nvarchar(50)",
            maxLength: 50,
            nullable: false,
            defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
