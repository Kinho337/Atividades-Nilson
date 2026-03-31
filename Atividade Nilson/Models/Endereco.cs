using System.ComponentModel.DataAnnotations;

namespace Atividade_Nilson.Models
{
    public class Endereco
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "CEP")]
        [Required(ErrorMessage = "O CEP é obrigatório.")]
        [MaxLength(10, ErrorMessage = "O CEP deve ter no máximo 10 caracteres.")]
        public string CEP { get; set; } = string.Empty;

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "O Estado é obrigatório.")]
        public string Estado { get; set; } = string.Empty;

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "A cidade é obrigatória.")]
        public string Cidade { get; set; } = string.Empty;

        [Display(Name = "Bairro")]
        [Required(ErrorMessage = "O bairro é obrigatório.")]
        public string Bairro { get; set; } = string.Empty;

        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "O endereço é obrigatório.")]
        public string Logradouro { get; set; } = string.Empty;

        [Display(Name = "Complemento")]
        public string? Complemento { get; set; }

        [Display(Name = "Número")]
        public string? Numero { get; set; }
    }
}