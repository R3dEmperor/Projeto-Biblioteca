using System.ComponentModel.DataAnnotations;

namespace Projeto_Biblioteca.DTO
{
    public class FuncionarioDTO : UsuarioDTO
    {
        [Key]
        public int IdTipoUsuario { get; set; }

        [Required, MaxLength(100)]
        public string DescricaoTipoUsuario { get; set; } = string.Empty;

        public virtual ICollection<UsuarioDTO>? Usuarios { get; set; }


    }
}
