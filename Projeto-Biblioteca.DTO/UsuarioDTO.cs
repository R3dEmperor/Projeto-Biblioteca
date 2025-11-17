using System.ComponentModel.DataAnnotations;

namespace Projeto_Biblioteca.DTO
{
    public class UsuarioDTO
    {
        [Key]
        public int Id { get; set; }

        // ========================
        // Dados pessoais básicos
        // ========================
        [Required, MaxLength(100)]
        public string Nome { get; set; } = string.Empty;

        [EmailAddress, MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Phone, MaxLength(20)]
        public string Telefone { get; set; } = string.Empty;

        public DateTime DataNascimento { get; set; }

        [MaxLength(14)]
        public string CPF { get; set; } = string.Empty;

        [MaxLength(20)]
        public string Sexo { get; set; } = "Não informado";

        public string? UrlFoto { get; set; }

        // ========================
        // Contas / Login
        // ========================
        [Required, MaxLength(50)]
        public string Usuario { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string Senha { get; set; } = string.Empty;

        // ========================
        // Tipo de Usuário (FK)
        // ========================
        public int TipoUsuarioId { get; set; }
        public virtual TipoUsuarioDTO? TipoUsuario { get; set; }
    }
}
