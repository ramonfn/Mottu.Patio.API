using System.ComponentModel.DataAnnotations;

namespace Mottu.Patio.API.Models.DTO
{
    public class FilialDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da filial é obrigatório.")]
        [StringLength(150, ErrorMessage = "O nome deve ter no máximo 150 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O endereço da filial é obrigatório.")]
        [StringLength(250, ErrorMessage = "O endereço deve ter no máximo 250 caracteres.")]
        public string Endereco { get; set; }
    }
}
