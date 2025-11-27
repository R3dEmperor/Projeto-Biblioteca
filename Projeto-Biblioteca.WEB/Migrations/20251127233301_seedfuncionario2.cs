using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Biblioteca.WEB.Migrations
{
    /// <inheritdoc />
    public partial class seedfuncionario2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Usuario (Nome,Senha_Usuario,Email_Usuario,TipoUsuarioId,Atividade) VALUES ('Administrador','123','Administrador@gmail.com',1,'TRUE'),('Funcionario','123','Funcionario@gmail.com',2,'TRUE')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
