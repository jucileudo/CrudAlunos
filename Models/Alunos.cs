using System.ComponentModel.DataAnnotations;

namespace CrudAlunos.Models
{
    public class Alunos
    {
        public Guid Id { get; set; } = new Guid();
        [Display(Name = "Matrícula")]
        [Required(ErrorMessage = "O Campo {0} é obrigatorio")]
        
        public int Matricula { get; set; }
        public string Nome { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O Campo {0} é obrigatorio")]
        [StringLength(maximumLength: 20, ErrorMessage = "O Campo {0} deve ter entre {2} e {1} caracteres", MinimumLength = 2)]
        
        public string CPF { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "O Campo {0} é obrigatorio")]
        [StringLength(maximumLength: 20, ErrorMessage = "O Campo {0} deve ter entre {2} e {1} caracteres", MinimumLength = 2)]
        [DataType(DataType.EmailAddress,ErrorMessage ="E-mail em formato inválido")]
        public string email { get; set; }
    }
}
