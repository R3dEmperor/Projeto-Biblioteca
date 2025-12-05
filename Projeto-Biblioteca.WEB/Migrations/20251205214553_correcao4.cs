using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Biblioteca.WEB.Migrations
{
    /// <inheritdoc />
    public partial class correcao4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Atividade",
                table: "Usuario",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Atividade",
                table: "Usuario",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
