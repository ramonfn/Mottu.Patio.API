using Mottu.Patio.API.Models.DTO;
using Mottu.Patio.API.Models;

namespace Mottu.Patio.API.Services.Mapping
{
    public static class UsuarioMapping
    {
        public static UsuarioDTO ToDTO(Usuario entity)
        {
            return new UsuarioDTO
            {
                Id = entity.Id,
                PrimeiroNome = entity.PrimeiroNome,
                Sobrenome = entity.Sobrenome,
                Email = entity.Email,
                Senha = entity.Senha
            };
        }

        public static Usuario ToEntity(UsuarioDTO dto)
        {
            return new Usuario
            {
                Id = dto.Id,
                PrimeiroNome = dto.PrimeiroNome,
                Sobrenome = dto.Sobrenome,
                Email = dto.Email,
                Senha = dto.Senha
            };
        }
    }
}