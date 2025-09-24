using System.ComponentModel.DataAnnotations;

namespace Mottu.Patio.API.Models
{
    /// <summary>
    /// Representa um usuário do sistema (operacional).
    /// </summary>
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        public int FilialId { get; set; }
        public Filial Filial { get; set; }

        [Required]
        public string PrimeiroNome { get; set; }

        [Required]
        public string Sobrenome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

        public string Cargo { get; set; }

        public int Idade { get; set; }
    }
}
