using Mottu.Patio.API.Data;
using Mottu.Patio.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mottu.Patio.API.Repositories.Interfaces;
using System.Linq;

namespace Mottu.Patio.API.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;
        public UsuarioRepository(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<Usuario>> GetAllAsync() => await _context.Usuarios.Include(u => u.Filial).ToListAsync();
        public async Task<Usuario> GetByIdAsync(int id) => await _context.Usuarios.Include(u => u.Filial).FirstOrDefaultAsync(u => u.Id == id);
        public async Task AddAsync(Usuario u) { _context.Usuarios.Add(u); await _context.SaveChangesAsync(); }
        public async Task UpdateAsync(Usuario u) { _context.Usuarios.Update(u); await _context.SaveChangesAsync(); }
        public async Task DeleteAsync(Usuario u) { _context.Usuarios.Remove(u); await _context.SaveChangesAsync(); }

        
        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Usuarios.FindAsync(id);
            if (entity != null)
            {
                _context.Usuarios.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<(IEnumerable<Usuario> items, int totalCount)> GetPagedAsync(int page, int pageSize)
        {
            var query = _context.Usuarios.AsQueryable();
            var total = await query.CountAsync();
            var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return (items, total);
        }

    }
}
