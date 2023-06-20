using System.ComponentModel.DataAnnotations;

namespace crud_pessoas.ViewModels
{
    public class AddPersonModel
    {
        [Required(ErrorMessage = "Informe o nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe o Sobrenome")]
        public string Sobrenome { get; set; }
        [Required(ErrorMessage = "Informe o Sexo")]
        public string Sexo { get; set; }
        [Required(ErrorMessage = "Informe a Profissão")]
        public string Profissao { get; set; }
    }
}
