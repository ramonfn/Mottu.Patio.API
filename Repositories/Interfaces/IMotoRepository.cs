using Mottu.Patio.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mottu.Patio.API.Repositories.Interfaces
{
    public interface IMotoRepository
    {
        Task<IEnumerable<Moto>> GetAllAsync();
        Task<Moto> GetByIdAsync(int id);
        Task<Moto> AddAsync(Moto moto);
        Task UpdateAsync(Moto moto);
        Task DeleteAsync(int id);

        Task<(IEnumerable<Moto> items, int totalCount)> GetPagedAsync(int page, int pageSize);
    }
}