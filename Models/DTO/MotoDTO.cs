using System.ComponentModel.DataAnnotations;

namespace Mottu.Patio.API.Models.DTO
{
    public class MotoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O modelo da moto é obrigatório.")]
        [StringLength(100, ErrorMessage = "O modelo deve ter no máximo 100 caracteres.")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "A placa da moto é obrigatória.")]
        [StringLength(10, ErrorMessage = "A placa deve ter no máximo 10 caracteres.")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "O ID da filial é obrigatório.")]
        public int FilialId { get; set; }
    }
}