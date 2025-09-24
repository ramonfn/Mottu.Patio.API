using Mottu.Patio.API.Data;
using Mottu.Patio.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mottu.Patio.API.Repositories.Interfaces;
using System.Linq;

namespace Mottu.Patio.API.Repositories
{
    public class FilialRepository : IFilialRepository
    {
        private readonly ApplicationDbContext _context;

        public FilialRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Filial>> GetAllAsync()
        {
            return await _context.Filiais.ToListAsync();
        }

        public async Task<Filial?> GetByIdAsync(int id)
        {
            return await _context.Filiais.FindAsync(id);
        }

        public async Task AddAsync(Filial filial)
        {
            _context.Filiais.Add(filial);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Filial filial)
        {
            _context.Filiais.Update(filial);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Filial filial)
        {
            _context.Filiais.Remove(filial);
            await _context.SaveChangesAsync();
        }

        
        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Filiais.FindAsync(id);
            if (entity != null)
            {
                _context.Filiais.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<(IEnumerable<Filial> items, int totalCount)> GetPagedAsync(int page, int pageSize)
        {
            var query = _context.Filiais.AsQueryable();
            var total = await query.CountAsync();
            var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return (items, total);
        }

    }
}
