using System.ComponentModel.DataAnnotations;

namespace Projeto_Biblioteca.DTO
{
    public class UsuarioDTO
    {
        public static object UsuarioLogado { get; set; }
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

        [MaxLength(14)]
        public string CPF { get; set; } = string.Empty;
        [MaxLength(14)]
        public string Endereco { get; set; } = string.Empty;
        // ========================
        // Contas / Login
        // ========================
        [Required, MaxLength(50)]
        public string Usuario { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string Senha { get; set; } = string.Empty;
        public bool atividade { get; set; } = true;
        // ========================
        // Tipo de Usuário (FK)
        // ========================
        public int TipoUsuarioId { get; set; }
        public virtual FuncionarioDTO? TipoUsuario { get; set; }

        public string? UrlFoto { get; set; }
    }
}
