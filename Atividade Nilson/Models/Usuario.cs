using System.ComponentModel.DataAnnotations;

namespace Atividade_Nilson.Models
{
    public class Usuario
    {
        [Display(Name = "Código")]
        public int IdUsu { get; set; }

        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string? nomeUsu { get; set; }

        [Display(Name = "Cargo")]
        [Required(ErrorMessage = "O campo cargo é obrigatório")]
        public string? Cargo { get; set; }

        [Display(Name = "Nascimento")]
        [Required(ErrorMessage = "O campo nascimento é obrigatório")]
        [DataType(DataType.Date)]
        public DateTime DataNasc { get; set; }

        [Display(Name = "CEP")]
        [Required(ErrorMessage = "O campo CEP é obrigatório")]
        public string? CEP { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "O campo Estado é obrigatório")]
        public string? Estado { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "O campo Cidade é obrigatório")]
        public string? Cidade { get; set; }

        [Display(Name = "Bairro")]
        [Required(ErrorMessage = "O campo Bairro é obrigatório")]
        public string? Bairro { get; set; }

        [Display(Name = "Logradouro")]
        [Required(ErrorMessage = "O campo Logradouro é obrigatório")]
        public string? Logradouro { get; set; }

        [Display(Name = "Complemento")]
        public string? Complemento { get; set; }

        [Display(Name = "Número")]
        [Required(ErrorMessage = "O campo Número é obrigatório")]
        public int Numero { get; set; }
    }
}