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
        //======================================================
        [Required(ErrorMessage = "Campo obrigatorio")]
        [Display(Name = "Usuario")]
        [StringLength(50)]
        public string Usuario_Usuario { get; set; }
        //======================================================
        [Required(ErrorMessage = "Campo obrigatorio")]
        [Display(Name = "Senha_Usuario")]
        [StringLength(50)]
        public string Senha_Usuario { get; set; }
        //=====================================================
        [Required(ErrorMessage = "Campo obrigatorio")]
        [Display(Name = "Endereço_Usuario")]
        [StringLength(50)]
        public string Endereco_Usuario { get; set; }
        //=====================================================
        [Display(Name = "Url_Usuario")]
        [StringLength(150)]
        public string URL_Usuario { get; set; }
        //=====================================================
        [Required(ErrorMessage = "Campo obrigatorio")]
        [Display(Name = "Email_Usuario")]
        [StringLength(50)]
        public string Email_Usuario { get; set; }
        //=====================================================
        [Required(ErrorMessage = "Campo obrigatorio")]
        [Display(Name = "CPF_Usuario")]
        [StringLength(50)]
        public string CPF_Usuario { get; set; }
        //=====================================================
        [Required(ErrorMessage = "Campo obrigatorio")]
        [Display(Name = "Telefone_Usuario")]
        [StringLength(50)]
        public string Telefone_Usuario { get; set; }
        //=====================================================
        [Display(Name = "Cargo Funcionario")]
        public int TipoUsuarioId { get; set; }
        public virtual Funcionario? TipoUsuario { get; set; }
        //=====================================================
        [Display(Name = "Em atividade")]
        public int Atividade { get; set; }
    }
}
