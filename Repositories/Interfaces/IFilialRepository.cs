using Mottu.Patio.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mottu.Patio.API.Repositories.Interfaces
{
    public interface IFilialRepository
    {
        Task<IEnumerable<Filial>> GetAllAsync();
        Task<Filial> GetByIdAsync(int id);
        Task AddAsync(Filial entity);
        Task UpdateAsync(Filial entity);
        Task DeleteAsync(int id);

        Task<(IEnumerable<Filial> items, int totalCount)> GetPagedAsync(int page, int pageSize);
    }
}
