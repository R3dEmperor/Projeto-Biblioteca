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
            migrationBuilder.Sql("INSERT INTO Usuario (Nome,Senha_Usuario,Email_Usuario,TipoUsuarioId) VALUES ('Administrador','123','Administrador@gmail.com',1),('Funcionario','123','Funcionario@gmail.com',2)");
            migrationBuilder.Sql("ALTER TABLE Usuario ALTER COLUMN Email_Usuario VARCHAR(100)");
            migrationBuilder.Sql("ALTER TABLE Usuario ALTER COLUMN Endereco_Usuario VARCHAR(100)");
            migrationBuilder.Sql("ALTER TABLE Usuario ALTER COLUMN Senha_Usuario VARCHAR(100)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
