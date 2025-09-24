using Mottu.Patio.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mottu.Patio.API.Services.Interfaces
{
    public interface IFilialService
    {
        Task<IEnumerable<Filial>> GetAllAsync();
        Task<Filial> GetByIdAsync(int id);
        Task<Filial> CreateAsync(Filial entity);
        Task UpdateAsync(Filial entity);
        Task DeleteAsync(int id);

        Task<(IEnumerable<Filial> items, int totalCount)> GetPagedAsync(int page, int pageSize);
    }
}
