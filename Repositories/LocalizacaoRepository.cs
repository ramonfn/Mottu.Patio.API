using Mottu.Patio.API.Data;
using Mottu.Patio.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mottu.Patio.API.Repositories.Interfaces;
using System.Linq;

namespace Mottu.Patio.API.Repositories
{
    public class LocalizacaoRepository : ILocalizacaoRepository
    {
        private readonly ApplicationDbContext _context;

        public LocalizacaoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Localizacao>> GetAllAsync()
        {
            return await _context.Localizacoes.ToListAsync();
        }

        public async Task<Localizacao?> GetByIdAsync(int id)
        {
            return await _context.Localizacoes.FindAsync(id);
        }

        public async Task AddAsync(Localizacao localizacao)
        {
            _context.Localizacoes.Add(localizacao);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Localizacao localizacao)
        {
            _context.Localizacoes.Update(localizacao);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Localizacao localizacao)
        {
            _context.Localizacoes.Remove(localizacao);
            await _context.SaveChangesAsync();
        }

        
        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Localizacoes.FindAsync(id);
            if (entity != null)
            {
                _context.Localizacoes.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<(IEnumerable<Localizacao> items, int totalCount)> GetPagedAsync(int page, int pageSize)
        {
            var query = _context.Localizacoes.AsQueryable();
            var total = await query.CountAsync();
            var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return (items, total);
        }

    }
}
