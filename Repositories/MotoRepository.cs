using Microsoft.EntityFrameworkCore;
using Mottu.Patio.API.Data;
using Mottu.Patio.API.Models;
using Mottu.Patio.API.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mottu.Patio.API.Repositories
{
    public class MotoRepository : IMotoRepository
    {
        private readonly ApplicationDbContext _context;
        public MotoRepository(ApplicationDbContext context) => _context = context;

        public async Task<Moto> AddAsync(Moto moto)
        {
            _context.Motos.Add(moto);
            await _context.SaveChangesAsync();
            return moto;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Motos.FindAsync(id);
            if (entity != null)
            {
                _context.Motos.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Moto>> GetAllAsync()
        {
            return await _context.Motos.Include(m => m.Filial).ToListAsync();
        }

        public async Task<Moto> GetByIdAsync(int id)
        {
            return await _context.Motos.Include(m => m.Filial).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task UpdateAsync(Moto moto)
        {
            _context.Motos.Update(moto);
            await _context.SaveChangesAsync();
        }
        public async Task<(IEnumerable<Moto> items, int totalCount)> GetPagedAsync(int page, int pageSize)
        {
            var query = _context.Motos.AsQueryable();
            var total = await query.CountAsync();
            var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return (items, total);
        }

    }
}