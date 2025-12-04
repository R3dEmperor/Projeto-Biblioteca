using System.ComponentModel.DataAnnotations;

namespace Projeto_Biblioteca.DTO
{
    public class FuncionarioDTO
    {
        [Key]
        public int IdCargo { get; set; }

        [Required, MaxLength(100)]
        public string NomeCargo { get; set; } = string.Empty;

        public virtual ICollection<UsuarioDTO>? Usuarios { get; set; }
    }
}
