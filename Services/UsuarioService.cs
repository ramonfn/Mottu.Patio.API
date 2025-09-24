using Mottu.Patio.API.Models;
using Mottu.Patio.API.Repositories.Interfaces;
using Mottu.Patio.API.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mottu.Patio.API.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repo;

        public UsuarioService(IUsuarioRepository repo)
            => _repo = repo;

        public async Task<IEnumerable<Usuario>> GetAllAsync()
            => await _repo.GetAllAsync();

        public async Task<Usuario> GetByIdAsync(int id)
            => await _repo.GetByIdAsync(id);

        public async Task<Usuario> CreateAsync(Usuario u)
        {
            await _repo.AddAsync(u);
            return u;
        }

        public async Task UpdateAsync(Usuario u)
            => await _repo.UpdateAsync(u);

        public async Task DeleteAsync(int id) { await _repo.DeleteAsync(id); }
        public async Task<(IEnumerable<Usuario> items, int totalCount)> GetPagedAsync(int page, int pageSize)
        {
            return await _repo.GetPagedAsync(page, pageSize);
        }

        public Task CreateAsync(object usuario)
        {
            throw new System.NotImplementedException();
        }
    }
}
