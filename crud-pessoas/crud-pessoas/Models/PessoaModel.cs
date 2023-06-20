using System.ComponentModel.DataAnnotations;

namespace crud_pessoas.Models
{
    public class PessoaModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe o nome")]
        public string Sobrenome { get; set; }
        [Required(ErrorMessage = "Informe o nome")]
        public string Sexo { get; set; }
        [Required(ErrorMessage = "Informe o nome")]
        public string Profissao { get; set; }
    }
}
