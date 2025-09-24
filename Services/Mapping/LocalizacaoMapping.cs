using Mottu.Patio.API.Models.DTO;
using Mottu.Patio.API.Models;

namespace Mottu.Patio.API.Services.Mapping
{
    public static class LocalizacaoMapping
    {
        public static LocalizacaoDTO ToDTO(Localizacao entity)
        {
            return new LocalizacaoDTO
            {
                Id = entity.Id,
                Latitude = (double)entity.Latitude,
                Longitude = (double)entity.Longitude,
                MotoId = entity.MotoId
            };
        }

        public static Localizacao ToEntity(LocalizacaoDTO dto)
        {
            return new Localizacao
            {
                Id = dto.Id,
                Latitude = (decimal)dto.Latitude,
                Longitude = (decimal)dto.Longitude,
                MotoId = dto.MotoId
            };
        }
    }
}
