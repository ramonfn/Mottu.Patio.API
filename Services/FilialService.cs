using Mottu.Patio.API.Models;
using Mottu.Patio.API.Repositories.Interfaces;
using Mottu.Patio.API.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mottu.Patio.API.Services
{
    public class FilialService : IFilialService
    {
        private readonly IFilialRepository _repo;

        public FilialService(IFilialRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Filial>> GetAllAsync() => await _repo.GetAllAsync();

        public async Task<(IEnumerable<Filial> items, int totalCount)> GetPagedAsync(int page, int pageSize)
            => await _repo.GetPagedAsync(page, pageSize);

        public async Task<Filial> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);

        public async Task<Filial> CreateAsync(Filial filial)
        {
            await _repo.AddAsync(filial);
            return filial;
        }

        public async Task UpdateAsync(Filial filial) => await _repo.UpdateAsync(filial);

        public async Task DeleteAsync(int id) => await _repo.DeleteAsync(id);
    }
}
