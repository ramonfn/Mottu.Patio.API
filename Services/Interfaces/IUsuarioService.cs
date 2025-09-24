using Mottu.Patio.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mottu.Patio.API.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<Usuario> GetByIdAsync(int id);
        Task<Usuario> CreateAsync(Usuario entity);
        Task UpdateAsync(Usuario entity);
        Task DeleteAsync(int id);

        Task<(IEnumerable<Usuario> items, int totalCount)> GetPagedAsync(int page, int pageSize);
        Task CreateAsync(object usuario);
    }
}
