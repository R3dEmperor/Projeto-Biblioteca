using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Biblioteca.WEB.Migrations
{
    /// <inheritdoc />
    public partial class seedTipoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE Funcionario ALTER COLUMN Descricao_Tipo VARCHAR(100)");
            migrationBuilder.Sql("INSERT INTO Funcionario (Descricao_Tipo) VALUES ('Administrador'),('Funcionario')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
