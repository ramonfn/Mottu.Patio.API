using Mottu.Patio.API.Models;
using Mottu.Patio.API.Repositories.Interfaces;
using Mottu.Patio.API.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mottu.Patio.API.Services
{
    public class MotoService : IMotoService
    {
        private readonly IMotoRepository _repo;

        public MotoService(IMotoRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Moto>> GetAllAsync() => await _repo.GetAllAsync();

        public async Task<(IEnumerable<Moto> items, int totalCount)> GetPagedAsync(int page, int pageSize)
            => await _repo.GetPagedAsync(page, pageSize);

        public async Task<Moto> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);

        public async Task<Moto> CreateAsync(Moto moto)
        {
            await _repo.AddAsync(moto);
            return moto;
        }

        public async Task UpdateAsync(Moto moto) => await _repo.UpdateAsync(moto);

        public async Task DeleteAsync(int id) => await _repo.DeleteAsync(id);
    }
}
