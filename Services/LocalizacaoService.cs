using Mottu.Patio.API.Models;
using Mottu.Patio.API.Repositories.Interfaces;
using Mottu.Patio.API.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mottu.Patio.API.Services
{
    public class LocalizacaoService : ILocalizacaoService
    {
        private readonly ILocalizacaoRepository _repo;

        public LocalizacaoService(ILocalizacaoRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Localizacao>> GetAllAsync() => await _repo.GetAllAsync();

        public async Task<(IEnumerable<Localizacao> items, int totalCount)> GetPagedAsync(int page, int pageSize)
            => await _repo.GetPagedAsync(page, pageSize);

        public async Task<Localizacao> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);

        public async Task<Localizacao> CreateAsync(Localizacao loc)
        {
            await _repo.AddAsync(loc);
            return loc;
        }

        public async Task UpdateAsync(Localizacao loc) => await _repo.UpdateAsync(loc);

        public async Task DeleteAsync(int id) => await _repo.DeleteAsync(id);
    }
}
