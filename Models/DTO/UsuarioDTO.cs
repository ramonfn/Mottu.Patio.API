using System.ComponentModel.DataAnnotations;

namespace Mottu.Patio.API.Models.DTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do usuário é obrigatório.")]
        [StringLength(150, ErrorMessage = "O nome deve ter no máximo 150 caracteres.")]
        public string PrimeiroNome { get; set; }
        [Required(ErrorMessage = "O sobrenome do usuário é obrigatório.")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de email inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 100 caracteres.")]
        public string Senha { get; set; }
    }
}