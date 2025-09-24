using Mottu.Patio.API.Models;
using Mottu.Patio.API.Models.DTO;

namespace Mottu.Patio.API.Services.Mapping
{
    public static class MotoMapping
    {
        public static MotoDTO ToDTO(Moto entity)
        {
            return new MotoDTO
            {
                Id = entity.Id,
                Modelo = entity.Modelo,
                Placa = entity.Placa,
                FilialId = entity.FilialId
            };
        }

        public static Moto ToEntity(MotoDTO dto)
        {
            return new Moto
            {
                Id = dto.Id,
                Modelo = dto.Modelo,
                Placa = dto.Placa,
                FilialId = dto.FilialId
            };
        }
    }
}
