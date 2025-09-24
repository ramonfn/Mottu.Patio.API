using Mottu.Patio.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mottu.Patio.API.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<Usuario> GetByIdAsync(int id);
        Task AddAsync(Usuario entity);
        Task UpdateAsync(Usuario entity);
        Task DeleteAsync(int id);

        Task<(IEnumerable<Usuario> items, int totalCount)> GetPagedAsync(int page, int pageSize);
    }
}
