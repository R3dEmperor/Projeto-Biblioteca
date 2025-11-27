using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Projeto_Biblioteca.WEB.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        //======================================================
        [Required(ErrorMessage = "Campo obrigatorio")]
        [Display(Name = "Nome")]
        [StringLength(50)]
        public string Nome { get; set; }
        //======================================================
        [Required(ErrorMessage = "Campo obrigatorio")]
        [Display(Name = "Email")]
        [StringLength(50)]
        public string Email { get; set; }
        //======================================================
        [Required(ErrorMessage = "Campo obrigatorio")]
        [Display(Name = "Senha")]
        [StringLength(50)]
        public string Senha_Usuario { get; set; }
        //=====================================================
        [Required(ErrorMessage = "Campo obrigatorio")]
        [Display(Name = "Endereço")]
        [StringLength(50)]
        public string Endereco_Usuario { get; set; }
        //=====================================================
        [Required(ErrorMessage = "Campo obrigatorio")]
        [Display(Name = "Email")]
        [StringLength(50)]
        public string Email_Usuario { get; set; }
        //=====================================================
        [Display(Name = "Cargo Funcionario")]
        public int TipoUsuarioId { get; set; }
        public virtual Funcionario? TipoUsuario { get; set; }
        //=====================================================
        [Display(Name = "Em atividade")]
        public bool Atividade { get; set; }
    }
}
