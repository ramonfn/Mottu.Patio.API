using System.ComponentModel.DataAnnotations;

namespace Mottu.Patio.API.Models.DTO
{
    public class LocalizacaoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A latitude é obrigatória.")]
        [Range(-90, 90, ErrorMessage = "Latitude inválida.")]
        public double Latitude { get; set; }

        [Required(ErrorMessage = "A longitude é obrigatória.")]
        [Range(-180, 180, ErrorMessage = "Longitude inválida.")]
        public double Longitude { get; set; }

        [Required(ErrorMessage = "O ID da moto é obrigatório.")]
        public int MotoId { get; set; }
    }
}
