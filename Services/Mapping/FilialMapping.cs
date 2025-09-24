using Mottu.Patio.API.Models.DTO;
using Mottu.Patio.API.Models;

namespace Mottu.Patio.API.Services.Mapping
{
    public static class FilialMapping
    {
        public static FilialDTO ToDTO(Filial entity)
        {
            return new FilialDTO
            {
                Id = entity.Id,
                Nome = entity.Nome,
                Endereco = entity.Endereco
            };
        }

        public static Filial ToEntity(FilialDTO dto)
        {
            return new Filial
            {
                Id = dto.Id,
                Nome = dto.Nome,
                Endereco = dto.Endereco
            };
        }
    }
}
