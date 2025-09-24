using Mottu.Patio.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mottu.Patio.API.Repositories.Interfaces
{
    public interface ILocalizacaoRepository
    {
        Task<IEnumerable<Localizacao>> GetAllAsync();
        Task<Localizacao> GetByIdAsync(int id);
        Task AddAsync(Localizacao entity);
        Task UpdateAsync(Localizacao entity);
        Task DeleteAsync(int id);

        Task<(IEnumerable<Localizacao> items, int totalCount)> GetPagedAsync(int page, int pageSize);
    }
}
